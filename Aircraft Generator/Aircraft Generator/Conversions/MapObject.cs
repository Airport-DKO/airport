using System.Web.UI.WebControls;

namespace Aircraft_Generator.FollowMeWs
{
    public partial class MapObject
    {
        public static implicit operator MapObject(GscWs2.MapObject m)
        {
            var mo = new MapObject()
            {
                MapObjectType = (FollowMeWs.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator MapObject(GmcVs.MapObject m)
        {
            var mo = new MapObject()
            {
                MapObjectType = (FollowMeWs.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator GscWs2.MapObject(MapObject m)
        {
            var mo = new GscWs2.MapObject()
            {
                MapObjectType = (GscWs2.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator GmcVs.MapObject(MapObject m)
        {
            var mo = new GmcVs.MapObject()
            {
                MapObjectType = (GmcVs.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }
    }
}