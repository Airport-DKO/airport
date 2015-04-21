using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Logic;

namespace WebApplication1.Data
{
    public class Data
    {
        #region Singleton_realization

        private static readonly Lazy<Data> _instance =
            new Lazy<Data>(() => new Data());

        public static Data Instance => _instance.Value;

        #endregion

        private const string MapSource = @"C:\Vizualizator\Map.xml";
        private const string MapObjectSource = @"C:\Vizualizator\MapObjects.xml";
        private const string RoutesSource = @"C:\Vizualizator\Routes.xml";
        private const string MapTxtSource = @"C:\Vizualizator\Map.txt";

        public List<CoordinateTuple> Map;
        public List<Location> MapObjects;
        public List<Route> Routes;

        public string MapString;

        private readonly Serializator _serializator;
        private Data()
        {
            _serializator = new Serializator();
            Map = _serializator.DeserializeMap(MapSource);
            MapObjects = _serializator.DesrrializeMapObject(MapObjectSource);
            Routes = _serializator.DeserializeRoute(RoutesSource);
            MapString = System.IO.File.ReadLines(MapTxtSource).Aggregate("", (current, line) => current + (line + "\0\n"));
        }

        public void RefreshMap()
        {
            Instance.Map = _serializator.DeserializeMap(MapSource);
        }

        public void RefreshMapObjects()
        {
            Instance.MapObjects = _serializator.DesrrializeMapObject(MapObjectSource);
        }

        public void RefreshRoutes()
        {
            Instance.Routes = _serializator.DeserializeRoute(RoutesSource);
        }

        public void RefreshMapString()
        {
            MapString = System.IO.File.ReadLines(MapTxtSource).Aggregate("", (current, line) => current + (line + "\0\n"));
        }
    }
}