using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Bidlokod;

namespace WebApplication1.Logic
{
    public class Parser
    {
        #region Singleton_realization

        private static readonly Lazy<Parser> _instance =
            new Lazy<Parser>(() => new Parser());

        public static Parser Instance
        {
            get { return _instance.Value; }
        }
        #endregion

        public List<CoordinateTuple> Map;
        public List<Location> MapObjects;
        public List<Route> Routes;
        private Parser()
        {
            Map = MyMap.GetMap();
            MapObjects = MyMapObject.GetMapObjects();
            Routes = MyRoute.GetRoute();
        }

        public void RefreshMap()
        {
            Instance.Map = MyMap.GetMap();
        }

        public void RefreshMapObjects()
        {
            Instance.MapObjects = MyMapObject.GetMapObjects();
        }

        public void RefreshRoutes()
        {
            Instance.Routes = MyRoute.GetRoute();
        }


    }
}