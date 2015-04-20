namespace Aircraft_Generator.GmcVs
{
    public partial class MapObject
    {
        public static implicit operator DeicerVs.MapObject(MapObject m)
        {
            var mo = new DeicerVs.MapObject()
            {
                MapObjectType = (DeicerVs.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator MapObject(DeicerVs.MapObject m)
        {
            var mo = new MapObject()
            {
                MapObjectType = (GmcVs.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }
    }
}