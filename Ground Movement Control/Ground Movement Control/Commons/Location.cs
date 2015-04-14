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

        public static implicit operator Location(VizualizatorWs.Location l)
        {
            var location = new Location(new CoordinateTuple(l.Position.X, l.Position.Y), l.MapObj);
            return location;
        }

        public static implicit operator VizualizatorWs.Location(Location l)
        {
            var location = new VizualizatorWs.Location();
            location.MapObj = l.MapObject;
            location.Position.X = l.Position.X;
            location.Position.Y = l.Position.Y;
            return location;
        }

    }
}