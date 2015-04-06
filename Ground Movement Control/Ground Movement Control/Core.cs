using System;
using System.Collections.Generic;
using System.Linq;
using Ground_Movement_Control.Commons;

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

        private readonly List<Location> _locations;
        private readonly List<MapPoint> _map;
        private readonly List<Route> _routes;

        private Core()
        {
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

            foreach (var location in _locations)
            {
                if (location.MapObject.MapObjectType != MapObjectType.Runway &&
                    location.MapObject.MapObjectType != MapObjectType.Airport)
                {
                    var mapPoint = _map.First(m => m.X == location.Position.X && m.Y == location.Position.Y);
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

        public MapObject CheckRunwayAwailability(Guid planeGuid)
        {
            var runwayLocation = GetActualRunway();
            if (runwayLocation == null)
            {
                return null;
            }

            if (!WeatherCheck())
            {
                return null;
            }

            var result = CheckVacantPosition(runwayLocation.Position.X, runwayLocation.Position.Y, MoveObjectType.Plane,
                planeGuid);
            if (result)
            {
                return runwayLocation.MapObject;
            }
            else
            {
                return null;
            }
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


        private bool CheckVacantPosition(Int32 x, Int32 y, MoveObjectType type, Guid id)
        {
            MapPoint mapPoint = _map.FirstOrDefault(m => m.X == x && m.Y == y);
            if (mapPoint == null)
            {
                return false;
            }
            if (mapPoint.State == MapPointState.Vacant)
            {
                if (mapPoint.TryMove(type, id))
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