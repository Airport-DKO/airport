using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ground_Movement_Control.Commons;
using Ground_Movement_Control.GscWs;
using Ground_Movement_Control.MetrologWs;
using Ground_Movement_Control.SnowPlugWs;
using Ground_Movement_Control.VizualizatorWs;
using CoordinateTuple = Ground_Movement_Control.Commons.CoordinateTuple;
using Location = Ground_Movement_Control.Commons.Location;
using MapObject = Ground_Movement_Control.Commons.MapObject;
using MapObjectType = Ground_Movement_Control.Commons.MapObjectType;
using MoveObjectType = Ground_Movement_Control.Commons.MoveObjectType;
using Route = Ground_Movement_Control.Commons.Route;

namespace Ground_Movement_Control
{
    public class Core
    {
        #region Singleton_realization

        private static readonly Lazy<Core> _instance =
            new Lazy<Core>(() => new Core());

        public static Core Instance
        {
            get { return _instance.Value; }
        }

        #endregion

        private static readonly object _lockObject = new object();
        private readonly GSC _gsc;
        private readonly List<Location> _locations;
        private readonly List<MapPoint> _map;
        private readonly MetrologService _metrolog;

        private readonly List<Tuple<Guid, MapObject>> _planesServiceZones;
        private readonly List<Route> _routes;
        private readonly Snowplug _snowplug;
        private readonly Visualisator _visualisator;

        private bool _isSnowNow;
        private Int32 _snowCooldown;

        private Core()
        {
            _gsc = new GSC();
            _visualisator = new Visualisator();
            _snowplug = new Snowplug();
            _metrolog = new MetrologService();
            _planesServiceZones = new List<Tuple<Guid, MapObject>>();
            _map = new List<MapPoint>();
            _routes = new List<Route>();
            _locations = new List<Location>();
            GetMapFromVizualizator();
            GetLocationsFromVisualizator();
            GetRoutesFromVizualizator();

            _isSnowNow = false;
            _snowCooldown = 0;
        }

        public List<CoordinateTuple> GetRoute(MapObject from, MapObject to)
        {
            if (_isSnowNow)
            {
                if (!(from.MapObjectType == MapObjectType.Garage && to.MapObjectType == MapObjectType.Garage))
                    return new List<CoordinateTuple>();
            }
            Location foundFromLocation = _locations.FirstOrDefault(
                l => (l.MapObject.MapObjectType == from.MapObjectType) && (l.MapObject.Number == from.Number));
            if (foundFromLocation == null)
            {
                Debug.WriteLine("Route not send. FROM not found");
                return new List<CoordinateTuple>();
            }
            Route foundRoute = foundFromLocation.Routes.FirstOrDefault(
                r => (r.To.MapObject.MapObjectType == to.MapObjectType) && (r.To.MapObject.Number == to.Number));
            if (foundRoute == null)
            {
                Debug.WriteLine("Route not send. TO not found");
                return new List<CoordinateTuple>();
            }
            Debug.WriteLine("Route send from {0} to {1}", from.MapObjectType, to.MapObjectType);
            return foundRoute.Points;
        }

        public bool Step(Int32 x, Int32 y, MoveObjectType type, Guid id, double speed)
        {
            lock (_lockObject)
            {
                _snowCooldown = 0;
            }
            return CheckVacantPosition(x, y, type, id, speed);
        }

        public void RunwayRelease(Int32 additionalX, Int32 additionalY)
        {
            Location runwayLocation = GetActualRunway();
            MapPoint runwayMapPoint =
                _map.First(m => m.X == runwayLocation.Position.X && m.Y == runwayLocation.Position.Y);
            runwayMapPoint.MakeVacant();
            MapPoint additionalMapPoint = _map.FirstOrDefault(m => m.X == additionalX && m.Y == additionalY);
            if (additionalMapPoint != null)
            {
                additionalMapPoint.MakeVacant();
            }
            Debug.WriteLine("Runway released");
        }

        public MapObject GetRunway()
        {
            Location runwayLocation = GetActualRunway();
            return runwayLocation.MapObject;
        }

        public bool CheckRunwayAwailability(Guid planeGuid, bool isArrival)
        {
            if (_isSnowNow)
                return false;
            Location runwayLocation = GetActualRunway();
            if (runwayLocation == null)
            {
                Debug.WriteLine("Declined to land plane {0} - runway not found", planeGuid);
                return false;
            }

            if (!WeatherCheck())
            {
                Debug.WriteLine("Declined to land plane {0} - bad weather", planeGuid);
                return false;
            }
            if (isArrival)
            {
                bool result = CheckVacantPosition(runwayLocation.Position.X, runwayLocation.Position.Y,
                    MoveObjectType.Plane,
                    planeGuid, 1000, true);
                if (!result)
                {
                    Debug.WriteLine("Declined to land plane {0} - runway is hold", planeGuid);
                    return false;
                }

                GscWs.MapObject serviceZone = _gsc.GetFreePlace(planeGuid);
                if (serviceZone == null)
                {
                    Debug.WriteLine("Declined to land plane {0} - runway no available service zones", planeGuid);
                    return false;
                }

                _planesServiceZones.Add(new Tuple<Guid, MapObject>(planeGuid, serviceZone));
                result = CheckVacantPosition(runwayLocation.Position.X, runwayLocation.Position.Y, MoveObjectType.Plane,
                    planeGuid, 1000);
                if (result)
                {
                    Debug.WriteLine("Accepted to land plane {0}", planeGuid);
                    return true;
                }
                Debug.WriteLine("Declined to land plane {0} - runway is hold but service zone is ready already. fuck",
                    planeGuid);
                return false;
            }
            else
            {
                bool result = CheckVacantPosition(runwayLocation.Position.X, runwayLocation.Position.Y,
                    MoveObjectType.Plane,
                    planeGuid, 1000);
                if (result)
                {
                    Debug.WriteLine("Accepted to takeoff plane {0}", planeGuid);
                    return true;
                }
                Debug.WriteLine("Declined to land plane {0}", planeGuid);
                return false;
            }
        }

        public MapObject GetPlaneServiceZone(Guid planeGuid)
        {
            Tuple<Guid, MapObject> tuple = _planesServiceZones.First(t => t.Item1 == planeGuid);
            if (tuple == null)
            {
                return null;
            }
            return tuple.Item2;
        }

        public List<MapObject> GetServiceZones()
        {
            IEnumerable<Location> szones =
                _locations.Where(l => l.MapObject.MapObjectType == MapObjectType.ServiceArea);
            return szones.Select(location => location.MapObject).ToList();
        }

        private void GetMapFromVizualizator()
        {
            _map.Clear();
            VizualizatorWs.CoordinateTuple[] mapFromVisual = _visualisator.GetMap();
            foreach (VizualizatorWs.CoordinateTuple coordinateTuple in mapFromVisual)
            {
                _map.Add(new MapPoint(coordinateTuple.X, coordinateTuple.Y));
            }
            //Конец заглушки
        }

        private void GetLocationsFromVisualizator()
        {
            _locations.Clear();
            //Начало заглушки
            VizualizatorWs.Location[] locationsFromVisual = _visualisator.GetMapObjects();
            foreach (VizualizatorWs.Location location in locationsFromVisual)
            {
                if (location.MapObj.Type == VizualizatorWs.MapObjectType.Garage ||
                    location.MapObj.Type == VizualizatorWs.MapObjectType.ServiceArea ||
                    location.MapObj.Type == VizualizatorWs.MapObjectType.Airport)
                {
                    MapPoint mapPoint = _map.First(m => m.X == location.Position.X && m.Y == location.Position.Y);
                    mapPoint.IsPublicPlace = true;
                }
                _locations.Add(location);
            }
        }

        private void GetRoutesFromVizualizator()
        {
            _routes.Clear();
            VizualizatorWs.Route[] routesFromVisual = _visualisator.GetRoutes();
            foreach (VizualizatorWs.Route route in routesFromVisual)
            {
                Location location =
                    _locations.First(
                        l =>
                            l.MapObject.MapObjectType == (MapObjectType) route.From.MapObj.Type &&
                            l.MapObject.Number == route.From.MapObj.number);
                location.Routes.Add(route);
            }
            //Конец заглушки
        }

        private Location GetActualRunway()
        {
            // TODO: Продумать реализацию нахождения рабочей взлетной полосы
            return _locations.FirstOrDefault(l => l.MapObject.MapObjectType == MapObjectType.Runway);
        }

        private bool WeatherCheck()
        {
            // TODO Проверка погоды на возможность посадки самолета
            return true;
        }


        private bool CheckVacantPosition(Int32 x, Int32 y, MoveObjectType type, Guid id, double speed,
            bool justTry = false)
        {
            MapPoint mapPoint = _map.FirstOrDefault(m => m.X == x && m.Y == y);
            if (mapPoint == null)
            {
                Debug.WriteLine("Declined to move object {0} to {1} {2} - NO MAP POINT FOUND", type, x, y);
                return false;
            }
            if (mapPoint.IsPublicPlace)
            {
                Debug.WriteLine("Move object {0} to {1} {2} PUBLIC PLACE BECOUSE HUESOS", type, x, y);
                _visualisator.MoveObject((VizualizatorWs.MoveObjectType) type, id,
                    new VizualizatorWs.CoordinateTuple {X = x, Y = y}, Convert.ToInt32(speed));
                MapPoint oldPoint =
                    _map.FirstOrDefault(m => m.OwnerGuid == id && (m.X != mapPoint.X || m.Y != mapPoint.Y));
                if (oldPoint != null)
                {
                    oldPoint.MakeVacant();
                }

                return true;
            }
            if (mapPoint.State == MapPointState.Vacant)
            {
                if (mapPoint.TryMove(type, id, justTry))
                {
                    MapPoint oldPoint =
                        _map.FirstOrDefault(m => m.OwnerGuid == id && (m.X != mapPoint.X || m.Y != mapPoint.Y));
                    if (oldPoint != null)
                    {
                        oldPoint.MakeVacant();
                    }
                    Debug.WriteLine("Move object {0} to {1} {2}", type, x, y);
                    if (!justTry)
                    {
                        _visualisator.MoveObject((VizualizatorWs.MoveObjectType) type, id,
                            new VizualizatorWs.CoordinateTuple {X = x, Y = y}, Convert.ToInt32(speed));
                    }
                    return true;
                }
                Debug.WriteLine("Declined to move object {0} to {1} {2} - MAP POINT WAS JUST HOLDED", type, x, y);
                return false;
            }
            if (mapPoint.OwnerGuid == id)
            {
                return true;
            }
            if (mapPoint.OwnerType == MoveObjectType.Plane && type == MoveObjectType.FollowMeVan)
            {
                Debug.WriteLine("Move object {0} to {1} {2} THIS IS FOLLOW ME INDA PLANE", type, x, y);
                _visualisator.MoveObject((VizualizatorWs.MoveObjectType) type, id,
                    new VizualizatorWs.CoordinateTuple {X = x, Y = y}, Convert.ToInt32(speed));
                MapPoint oldPoint =
                    _map.FirstOrDefault(m => m.OwnerGuid == id && (m.X != mapPoint.X || m.Y != mapPoint.Y));
                if (oldPoint != null)
                {
                    oldPoint.MakeVacant();
                }
                return true;
            }
            Debug.WriteLine("Declined to move object {0} to {1} {2} - HOLD POINT", type, x, y);
            return false;
        }

        public void SnowCleanFinished()
        {
            _isSnowNow = false;
        }

        public void LetItSnow()
        {
            _isSnowNow = true;
            //_visualisator.LetItSnow();
            new Task(SnowTask).Start();
        }

        private void SnowTask()
        {
            while (_snowCooldown <= 20)
            {
                _snowCooldown++;

                double sleepTime = 1000*_metrolog.GetCurrentTick();
                Thread.Sleep(Convert.ToInt32(sleepTime));
            }

            List<CoordinateTuple> route = GetRoute(new MapObject(MapObjectType.Garage, 0),
                new MapObject(MapObjectType.Garage, 0));
            var sergejRoute = new SnowPlugWs.CoordinateTuple[route.Count];
            for (int i = 0; i < route.Count; i++)
            {
                sergejRoute[i] = route[i];
            }
            _snowplug.Clean(sergejRoute);
        }


        public void Reset()
        {
            foreach (MapPoint mapPoint in _map)
            {
                mapPoint.MakeVacant();
            }
        }
    }
}