using System;
using Aircraft_Generator.GscWs2;
using MapObject = Aircraft_Generator.GmcVs.MapObject;

namespace Aircraft_Generator.Commons
{
    public class Plane
    {
        public Plane(string name, PlaneState state, PlaneType type, int fuelNeed, int maxStandartPassengers,
            int maxVipPassengers, bool hasArrivalPassengers)
        {
            Id = Guid.NewGuid();
            Name = name;
            State = state;
            Type = type;
            FuelNeed = fuelNeed;
            MaxStandartPassengers = maxStandartPassengers;
            MaxVipPassengers = maxVipPassengers;
            HasArrivalPassengers = hasArrivalPassengers;

            // Отправка запроса в Табло и получение номера рейса

            // Начало заглушки
            Flight = new Flight();
            // Конец заглушки
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
        public Int32 MaxStandartPassengers { get; set; }
        public Int32 MaxVipPassengers { get; set; }
        public bool HasArrivalPassengers { get; set; }

        public MapObject ServiceZone { get; set; }
    }
}