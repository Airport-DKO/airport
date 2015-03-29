using System;
using System.Collections.Generic;

namespace Ground_Movement_Control.Commons
{
    public class Location
    {
        public Location(CoordinateTuple position, MapObject mapObject)
        {
            Position = position;
            MapObject = mapObject;
            Routes=new List<Route>();
        }

        public Location()
        {
            Routes=new List<Route>();
        }

        public CoordinateTuple Position { get; set; }
        public MapObject MapObject { get; set; }
        public List<Route> Routes { get; set; }
    }
}