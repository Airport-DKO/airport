namespace BaggageTractor.GmcVS
{
    public partial class MapObject
    {
        public static implicit operator AircraftGeneratorVS.MapObject(MapObject obj)
        {
            var newobj = new AircraftGeneratorVS.MapObject
            {
                MapObjectType = (AircraftGeneratorVS.MapObjectType) obj.MapObjectType,
                Number = obj.Number
            };
            return newobj;
        }

        public static implicit operator MapObject(AircraftGeneratorVS.MapObject obj)
        {
            var newobj = new MapObject {MapObjectType = (MapObjectType) obj.MapObjectType, Number = obj.Number};
            return newobj;
        }
    }
}