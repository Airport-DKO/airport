namespace Ground_Service_Control.GMC
{
    public partial class MapObject
    {
        public static implicit operator MapObject(BaggageTractor.MapObject m)
        {
            var mo = new MapObject()
            {
                MapObjectType = (MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator BaggageTractor.MapObject(MapObject m)
        {
            var mo = new BaggageTractor.MapObject()
            {
                MapObjectType = (BaggageTractor.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator MapObject(CateringTruck.MapObject m)
        {
            var mo = new MapObject()
            {
                MapObjectType = (MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator CateringTruck.MapObject(MapObject m)
        {
            var mo = new CateringTruck.MapObject()
            {
                MapObjectType = (CateringTruck.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator MapObject(ContainerLoader.MapObject m)
        {
            var mo = new MapObject()
            {
                MapObjectType = (MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator ContainerLoader.MapObject(MapObject m)
        {
            var mo = new ContainerLoader.MapObject()
            {
                MapObjectType = (ContainerLoader.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator MapObject(PassengerBus.MapObject m)
        {
            var mo = new MapObject()
            {
                MapObjectType = (MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator PassengerBus.MapObject(MapObject m)
        {
            var mo = new PassengerBus.MapObject()
            {
                MapObjectType = (PassengerBus.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator MapObject(PassengerStairs.MapObject m)
        {
            var mo = new MapObject()
            {
                MapObjectType = (MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator PassengerStairs.MapObject(MapObject m)
        {
            var mo = new PassengerStairs.MapObject()
            {
                MapObjectType = (PassengerStairs.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator MapObject(Refueler.MapObject m)
        {
            var mo = new MapObject()
            {
                MapObjectType = (MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator Refueler.MapObject(MapObject m)
        {
            var mo = new Refueler.MapObject()
            {
                MapObjectType = (Refueler.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator MapObject(VIPShuttle.MapObject m)
        {
            var mo = new MapObject()
            {
                MapObjectType = (MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }

        public static implicit operator VIPShuttle.MapObject(MapObject m)
        {
            var mo = new VIPShuttle.MapObject()
            {
                MapObjectType = (VIPShuttle.MapObjectType)m.MapObjectType,
                Number = m.Number
            };
            return mo;
        }
    }
}