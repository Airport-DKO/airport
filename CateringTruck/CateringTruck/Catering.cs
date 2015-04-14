namespace CateringTruck.ChechinVS
{
    public partial class Catering
    {
        public static implicit operator AircraftGeneratorVS.Catering(Catering obj)
        {
            var newobj = new AircraftGeneratorVS.Catering
            {
                Children = obj.Children,
                Default = obj.Default,
                Diabetic = obj.Diabetic,
                LowCalorie = obj.LowCalorie,
                Vegetarian = obj.Vegetarian
            };
            return newobj;
        }

        public static implicit operator Catering(AircraftGeneratorVS.Catering obj)
        {
            var newobj = new Catering
            {
                Children = obj.Children,
                Default = obj.Default,
                Diabetic = obj.Diabetic,
                LowCalorie = obj.LowCalorie,
                Vegetarian = obj.Vegetarian
            };
            return newobj;
        }
    }
}