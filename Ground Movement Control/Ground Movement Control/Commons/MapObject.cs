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
    }
}