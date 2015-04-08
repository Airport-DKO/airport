namespace PassengerBus.GmcVS
{
    public partial class MapObject 
    {
        public static implicit operator AircraftgeneratorVS.MapObject(MapObject obj)
        {
            var newobj = new AircraftgeneratorVS.MapObject
            {
                MapObjectType = (AircraftgeneratorVS.MapObjectType) obj.MapObjectType,
                Number = obj.Number
            };
            return newobj;

        }

        public static implicit operator MapObject(AircraftgeneratorVS.MapObject obj)
        {
            var newobj = new MapObject {MapObjectType = (MapObjectType) obj.MapObjectType, Number = obj.Number};
            return newobj;

        }
    }
}