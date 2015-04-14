namespace Aircraft_Generator.InformationPanelWS
{
    public partial class Flight
    {
        public static implicit operator Flight(GscWs2.Flight f)
        {
            var newFlight = new Flight
            {
                number = f.number,
                city = (Cities)f.city,
                arrivalTime = f.arrivalTime,
                takeoffTime = f.takeoffTime,
                StartRegistrationTime = f.StartRegistrationTime,
                VipPassengersCount = f.VipPassengersCount,
                BindPlaneID = f.BindPlaneID,
                IsReadyTakeOff = f.IsReadyTakeOff,
                EconomPassengersCount = f.EconomPassengersCount,
                EndRegistrationTime = f.EndRegistrationTime
            };
            return newFlight;
        }

        public static implicit operator GscWs2.Flight(Flight f)
        {
            var newFlight = new GscWs2.Flight
            {
                number = f.number,
                city = (GscWs2.Cities)f.city,
                arrivalTime = f.arrivalTime,
                takeoffTime = f.takeoffTime,
                StartRegistrationTime = f.StartRegistrationTime,
                VipPassengersCount = f.VipPassengersCount,
                BindPlaneID = f.BindPlaneID,
                IsReadyTakeOff = f.IsReadyTakeOff,
                EconomPassengersCount = f.EconomPassengersCount,
                EndRegistrationTime = f.EndRegistrationTime
            };
            return newFlight;
        }
    }
}