using System;
using System.Collections.Generic;
using System.Linq;
using Ground_Movement_Control.Commons;
using Ground_Movement_Control.GscWs;
using MapObject = Ground_Movement_Control.Commons.MapObject;
using MapObjectType = Ground_Movement_Control.Commons.MapObjectType;

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
        private readonly List<Location> _locations;
        private readonly List<MapPoint> _map;

        private readonly List<Tuple<Guid, MapObject>> _planesServiceZones;
        private readonly List<Route> _routes;

        private Core()
        {
            _gsc = new GSC();
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
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
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
            _locations.Add(new Location(new CoordinateTuple(25, 25), new MapObject(MapObjectType.Garage, 0)));
            _locations.Add(new Location(new CoordinateTuple(25, 0), new MapObject(MapObjectType.Airport, 0)));
            _locations.Add(new Location(new CoordinateTuple(14, 14), new MapObject(MapObjectType.ServiceArea, 1)));
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
                l => (l.MapObject.MapObjectType == MapObjectType.ServiceArea) && (l.MapObject.Number == 1));
            Location neededLocation2 = _locations.FirstOrDefault(
                l => (l.MapObject.MapObjectType == MapObjectType.Garage) && (l.MapObject.Number == 0));
            var route = new Route(neededLocation1, neededLocation2, new List<CoordinateTuple>
            {
                new CoordinateTuple(14, 15),
                new CoordinateTuple(15, 15),
                new CoordinateTuple(15, 16),
                new CoordinateTuple(15, 17),
                new CoordinateTuple(15, 18),
                new CoordinateTuple(15, 19),
                new CoordinateTuple(15, 20),
                new CoordinateTuple(15, 21),
                new CoordinateTuple(15, 22),
                new CoordinateTuple(15, 23),
                new CoordinateTuple(15, 24),
                new CoordinateTuple(15, 25),
                new CoordinateTuple(16, 25),
                new CoordinateTuple(17, 25),
                new CoordinateTuple(18, 25),
                new CoordinateTuple(19, 25),
                new CoordinateTuple(20, 25),
                new CoordinateTuple(21, 25),
                new CoordinateTuple(22, 25),
                new CoordinateTuple(23, 25),
                new CoordinateTuple(24, 25),
                new CoordinateTuple(25, 25),
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

        public MapObject CheckRunwayAwailability(Guid planeGuid)
        {
            Location runwayLocation = GetActualRunway();
            if (runwayLocation == null)
            {
                return null;
            }

            if (!WeatherCheck())
            {
                return null;
            }

            bool result = CheckVacantPosition(runwayLocation.Position.X, runwayLocation.Position.Y, MoveObjectType.Plane,
                planeGuid, true);
            if (!result)
            {
                return null;
            }
            GscWs.MapObject serviceZone = _gsc.GetFreePlace(planeGuid);
            if (serviceZone == null)
            {
                return null;
            }
            _planesServiceZones.Add(new Tuple<Guid, MapObject>(planeGuid, serviceZone));
            result = CheckVacantPosition(runwayLocation.Position.X, runwayLocation.Position.Y, MoveObjectType.Plane,
                planeGuid);
            if (result)
            {
                return runwayLocation.MapObject;
            }
            return null;
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
                    MapPoint oldPoint = _map.FirstOrDefault(m => m.OwnerGuid == id);
                    if (oldPoint != null)
                    {
                        oldPoint.MakeVacant();
                    }
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}