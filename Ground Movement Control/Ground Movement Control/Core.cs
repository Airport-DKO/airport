using System;
using System.Collections.Generic;
using System.Linq;
using Ground_Movement_Control.Commons;
using Ground_Movement_Control.GscWs;
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

        private readonly GSC _gsc;
        private readonly VizualizatorWs.visualisator _visualisator;
        private readonly List<Location> _locations;
        private readonly List<MapPoint> _map;

        private readonly List<Tuple<Guid, MapObject>> _planesServiceZones;
        private readonly List<Route> _routes;

        private Core()
        {
            _gsc = new GSC();
            _visualisator=new visualisator();
            _planesServiceZones = new List<Tuple<Guid, MapObject>>();
            _map = new List<MapPoint>();
            _routes = new List<Route>();
            _locations = new List<Location>();
            GetMapFromVizualizator();
            GetLocationsFromVisualizator();
            GetRoutesFromVizualizator();
        }

        private void GetMapFromVizualizator()
        {
            _map.Clear();
            //Начало заглушки
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 39; j++)
                {
                    _map.Add(new MapPoint(i, j));
                }
            }
            //Конец заглушки
        }

        private void GetLocationsFromVisualizator()
        {
            _locations.Clear();
            //Начало заглушки
            _locations.Add(new Location(new CoordinateTuple(0, 0), new MapObject(MapObjectType.Runway, 1)));
            _locations.Add(new Location(new CoordinateTuple(0, 25), new MapObject(MapObjectType.Runway, 2)));
            _locations.Add(new Location(new CoordinateTuple(10, 10), new MapObject(MapObjectType.Garage, 0)));
            _locations.Add(new Location(new CoordinateTuple(5, 0), new MapObject(MapObjectType.Airport, 0)));
            _locations.Add(new Location(new CoordinateTuple(4, 14), new MapObject(MapObjectType.ServiceArea, 1)));
            //Конец заглушки

            foreach (Location location in _locations)
            {
                if (location.MapObject.MapObjectType != MapObjectType.Runway &&
                    location.MapObject.MapObjectType != MapObjectType.Airport)
                {
                    MapPoint mapPoint = _map.First(m => m.X == location.Position.X && m.Y == location.Position.Y);
                    mapPoint.IsPublicPlace = true;
                }
            }
        }

        private void GetRoutesFromVizualizator()
        {
            _routes.Clear();
            //Начало заглушки
            Location neededLocation1 = _locations.FirstOrDefault(
                l => (l.MapObject.MapObjectType == MapObjectType.Garage) && (l.MapObject.Number == 0));
            Location neededLocation2 = _locations.FirstOrDefault(
                l => (l.MapObject.MapObjectType == MapObjectType.ServiceArea) && (l.MapObject.Number == 1));
            var route = new Route(neededLocation1, neededLocation2, new List<CoordinateTuple>
            {
                new CoordinateTuple(4, 15),
                new CoordinateTuple(5, 15),
                new CoordinateTuple(5, 16),
                new CoordinateTuple(5, 17),
                new CoordinateTuple(5, 18),
                new CoordinateTuple(5, 19),
                new CoordinateTuple(5, 20),
            });
            neededLocation1.Routes.Add(route);

             neededLocation1 = _locations.FirstOrDefault(
    l => (l.MapObject.MapObjectType == MapObjectType.Garage) && (l.MapObject.Number == 0));
             neededLocation2 = _locations.FirstOrDefault(
                l => (l.MapObject.MapObjectType == MapObjectType.Runway) && (l.MapObject.Number == 1));
             route = new Route(neededLocation1, neededLocation2, new List<CoordinateTuple>
            {
                new CoordinateTuple(4, 15),
                new CoordinateTuple(5, 15),
                new CoordinateTuple(5, 16),
                new CoordinateTuple(5, 17),
                new CoordinateTuple(5, 18),
                new CoordinateTuple(5, 19),
                new CoordinateTuple(5, 20),
                new CoordinateTuple(5, 21),
                new CoordinateTuple(5, 22),
                new CoordinateTuple(5, 23),
                new CoordinateTuple(5, 24),
                new CoordinateTuple(5, 25),
                new CoordinateTuple(6, 25),
                new CoordinateTuple(7, 25),
                new CoordinateTuple(8, 25),
                new CoordinateTuple(9, 25),
                new CoordinateTuple(0, 25),
                new CoordinateTuple(1, 25),
                new CoordinateTuple(2, 25),
                new CoordinateTuple(3, 25),
                new CoordinateTuple(4, 25),
                new CoordinateTuple(5, 25),
            });
            neededLocation1.Routes.Add(route);

            _routes.Add(route);
            //Конец заглушки
        }

        public List<CoordinateTuple> GetRoute(MapObject from, MapObject to)
        {
            Location foundFromLocation = _locations.FirstOrDefault(
                l => (l.MapObject.MapObjectType == from.MapObjectType) && (l.MapObject.Number == from.Number));
            if (foundFromLocation == null)
            {
                return new List<CoordinateTuple>();
            }
            Route foundRoute = foundFromLocation.Routes.FirstOrDefault(
                r => (r.To.MapObject.MapObjectType == to.MapObjectType) && (r.To.MapObject.Number == to.Number));
            if (foundRoute == null)
            {
                return new List<CoordinateTuple>();
            }
            return foundRoute.Points;
        }

        public bool Step(Int32 x, Int32 y, MoveObjectType type, Guid id)
        {
            return CheckVacantPosition(x, y, type, id);
        }

        public void RunwayRelease()
        {
            Location runwayLocation = GetActualRunway();
            MapPoint runwayMapPoint =
                _map.First(m => m.X == runwayLocation.Position.X && m.Y == runwayLocation.Position.Y);
            runwayMapPoint.MakeVacant();
        }

        public MapObject GetRunway()
        {
            Location runwayLocation = GetActualRunway();
            return runwayLocation.MapObject;
        }

        public bool CheckRunwayAwailability(Guid planeGuid)
        {
            Location runwayLocation = GetActualRunway();
            if (runwayLocation == null)
            {
                return false;
            }

            if (!WeatherCheck())
            {
                return false;
            }

            bool result = CheckVacantPosition(runwayLocation.Position.X, runwayLocation.Position.Y, MoveObjectType.Plane,
                planeGuid, true);
            if (!result)
            {
                return false;
            }
            GscWs.MapObject serviceZone = _gsc.GetFreePlace(planeGuid);
            if (serviceZone == null)
            {
                return false;
            }
            _planesServiceZones.Add(new Tuple<Guid, MapObject>(planeGuid, serviceZone));
            result = CheckVacantPosition(runwayLocation.Position.X, runwayLocation.Position.Y, MoveObjectType.Plane,
                planeGuid);
            if (result)
            {
                return true;
            }
            return false;
        }

        public MapObject GetPlaneServiceZone(Guid planeGuid)
        {
            Tuple<Guid, MapObject> tuple = _planesServiceZones.First(t => t.Item1 == planeGuid);
            if (tuple == null)
                return null;
            return tuple.Item2;
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


        private bool CheckVacantPosition(Int32 x, Int32 y, MoveObjectType type, Guid id, bool justTry = false)
        {
            MapPoint mapPoint = _map.FirstOrDefault(m => m.X == x && m.Y == y);
            if (mapPoint == null)
            {
                return false;
            }
            if (mapPoint.State == MapPointState.Vacant)
            {
                if (mapPoint.TryMove(type, id, justTry))
                {
                    MapPoint oldPoint = _map.FirstOrDefault(m => m.OwnerGuid == id && m.X != mapPoint.X && m.Y != mapPoint.Y);
                    if (oldPoint != null)
                    {
                            oldPoint.MakeVacant();
                    }
                    //DEBUG
                    _visualisator.MoveObject(VizualizatorWs.MoveObjectType.Plane, id,new VizualizatorWs.CoordinateTuple(){X=x, Y=y},5 );
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<MapObject> GetServiceZones()
        {
            var szones=_locations.Where(l => l.MapObject.MapObjectType == MapObjectType.ServiceArea);
            return szones.Select(location => location.MapObject).ToList();
        }
    }
}