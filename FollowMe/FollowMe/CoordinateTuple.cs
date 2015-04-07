namespace FollowMe.GmcVS
{
    public partial class CoordinateTuple
    {
        public static implicit operator CoordinateTuple(AircraftGeneratorVS.CoordinateTuple obj)
        {
            var newobj = new CoordinateTuple {X = obj.X, Y = obj.Y};
            return newobj;
        }

        public static implicit operator AircraftGeneratorVS.CoordinateTuple(CoordinateTuple obj)
        {
            var newobj = new AircraftGeneratorVS.CoordinateTuple {X = obj.X, Y = obj.Y};
            return newobj;
        }
    }
}