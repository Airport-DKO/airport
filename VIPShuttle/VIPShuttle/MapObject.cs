namespace VIPShuttle.GmcVS
{
    public partial class MapObject
    {
        public static implicit operator AircraftgeneratorVS.MapObject(MapObject obj)
        {
            var newobj = new AircraftgeneratorVS.MapObject();
            newobj.MapObjectType = (AircraftgeneratorVS.MapObjectType)obj.MapObjectType;
            newobj.Number = obj.Number;
            return newobj;

        }

        public static implicit operator MapObject(AircraftgeneratorVS.MapObject obj)
        {
            var newobj = new MapObject();
            newobj.MapObjectType = (MapObjectType)obj.MapObjectType;
            newobj.Number = obj.Number;
            return newobj;

        }
    }
}