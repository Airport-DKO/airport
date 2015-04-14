using System;

namespace Ground_Movement_Control.Commons
{
    public class MapObject
    {
        public MapObject()
        {
        }

        public MapObject(MapObjectType mapObjectType, int number)
        {
            MapObjectType = mapObjectType;
            Number = number;
        }

        public MapObject(MapObjectType mapObjectType)
        {
            MapObjectType = mapObjectType;
            Number = 0;
        }

        public MapObjectType MapObjectType { get; set; }
        public Int32 Number { get; set; }

        public static implicit operator MapObject(GscWs.MapObject m)
        {
            var mapObject = new MapObject()
            {
                MapObjectType = (Commons.MapObjectType) m.MapObjectType,
                Number = m.Number
            };
            return mapObject;
        }

        public static implicit operator GscWs.MapObject(MapObject m)
        {
            var mapObject = new GscWs.MapObject()
            {
                MapObjectType =(GscWs.MapObjectType) m.MapObjectType,
                Number = m.Number
            };
            return mapObject;
        }

        public static implicit operator MapObject(VizualizatorWs.MapObject m)
        {
            var mapObject = new MapObject()
            {
                
                MapObjectType = (Commons.MapObjectType)m.Type,
                Number = m.number
            };
            return mapObject;
        }

        public static implicit operator VizualizatorWs.MapObject(MapObject m)
        {
            var mapObject = new VizualizatorWs.MapObject()
            {
                Type = (VizualizatorWs.MapObjectType)m.MapObjectType,
                number = m.Number
            };
            return mapObject;
        }
    }
}