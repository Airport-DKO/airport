using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication1.Logic
{
    [Serializable()]
    public class Route
    {
        [XmlElement("From")]
        public Location From;
        [XmlElement("To")]
        public Location To;
        [XmlElement("Points")]
        public List<CoordinateTuple> Points;
    }

    [Serializable()]
    public class Location
    {
        [XmlElement("Position")]
        public CoordinateTuple Position { get; set; }
        [XmlElement("MapObj")]
        public MapObject MapObj { get; set; }
    }

    [Serializable()]
    public class MapObject
    {
        [XmlElement("Type")]
        public MapObjectType Type { get; set; }
        [XmlElement("number")]
        public int number { get; set; }
    }

    [Serializable()]
    public class CoordinateTuple
    {
        private int x;
        [XmlElement("X")]
        public int X
        {
            get { return x; } set { if (value > 0) x = value; }
        }

        private int y;
        [XmlElement("Y")]
        public int Y
        {
            get { return y; } set { if (value > 0) y = value; }
        }

    }

    public enum MoveObjectType
    {
        None,
        Plane,
        FollowMeVan,
        ContainerLoader,
        BaggageTractor,
        CateringTruck,
        Deicer,
        PassengerStairs,
        PassengerBus,
        VipShuttle,
        SnowRemovalVehicle
    }

    public enum MapObjectType
    {
        Runway,
        Garage,
        ServiceArea,
        Airport
    }


}