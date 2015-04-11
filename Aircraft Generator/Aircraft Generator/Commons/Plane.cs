using System;
using Aircraft_Generator.GscWs2;
using MapObject = Aircraft_Generator.GmcVs.MapObject;
using Flight=Aircraft_Generator.InformationPanelWS.Flight;

namespace Aircraft_Generator.Commons
{
    public class Plane
    {
        public Plane(string name, Flight flight, PlaneState state, PlaneType type, int fuelNeed, int currentStandartPassengers, int currentVipPassengers, int currentBaggage, int currentCatering, bool hasArrivalPassengers)
        {
            Id = Guid.NewGuid();
            Name = name;
            Flight = flight;
            State = state;
            Type = type;
            FuelNeed = fuelNeed;
            CurrentStandartPassengers = currentStandartPassengers;
            CurrentVipPassengers = currentVipPassengers;
            CurrentBaggage = currentBaggage;
            CurrentCatering = currentCatering;
            HasArrivalPassengers = hasArrivalPassengers;
        }

        public Plane()
        {
        }

        public Guid Id { get; set; }
        public String Name { get; set; }
        public Flight Flight { get; set; }
        public PlaneState State { get; set; }
        public PlaneType Type { get; set; }
        public Int32 FuelNeed { get; set; }
        public Int32 CurrentStandartPassengers { get; set; }
        public Int32 CurrentVipPassengers { get; set; }
        public Int32 CurrentBaggage { get; set; }
        public Int32 CurrentCatering { get; set; }
        public bool HasArrivalPassengers { get; set; }

        public MapObject ServiceZone { get; set; }
    }
}