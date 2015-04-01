using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PassengerBus.GmcVS;

namespace PassengerBus
{
    public static class Worker
    {
        private static readonly MapObject Garage;
        private static readonly MapObject Airport;

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };

            Airport = new MapObject { MapObjectType = MapObjectType.Airport };
        }

        public static void ToAirport(MapObject place, int countOfPassengers, int taskId)
        {
            var buses = new List<Bus>();
            var tasks = new List<Task>();

            while (countOfPassengers > 0)
            {
                var bus = new Bus();
                buses.Add(bus);

                var t = new Task(() =>
                {
                    bus.GoTo(Garage, place);
                    bus.GoTo(place, Airport);
                });
                t.Start();
                tasks.Add(t);

                countOfPassengers -= bus.Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            //TODO: РАССКОМЕНТИТЬ, КОГДА БУДЕТ УНО
            //Done(taskId);

            foreach (var bus in buses)
            {
                var t = new Task(() => bus.GoTo(Airport, Garage));
                t.Start();
            }
        }

        public static void ToPlain(MapObject place, int flightNumber, int taskId)
        {
            //TODO: ИЗМЕНИТЬ, КОГДА БУДЕТ ГОТОВА РЕГИСТРАЦИЯ
            //var passengers = GetVips(flightNumber);
            var passengers = new List<Guid>();

            var buses = new List<Bus>();
            var tasks = new List<Task>();

            var countOfPassengers = passengers.Count;
            var busNumber = 0;
            while (countOfPassengers>0)
            {
                var bus = new Bus();
                buses.Add(bus);

                var t = new Task(() =>
                {
                    bus.GoTo(Garage, Airport);
                    bus.GoTo(Airport, place);
                    bus.CarryPassengers(flightNumber, passengers.GetRange(busNumber * bus.Capacity, bus.Capacity));
                });

                t.Start();
                tasks.Add(t);

                countOfPassengers -= bus.Capacity;
                busNumber++;
            }

            Task.WaitAll(tasks.ToArray());

            //TODO: РАССКОМЕНТИТЬ, КОГДА БУДЕТ УНО
            //Done(taskId);

            foreach (var bus in buses)
            {
                var t = new Task(() => bus.GoTo(place, Garage));
                t.Start();
            }
        }

        public static int GetPassengersCount(int flightNumber)
        {
            //TODO: ИЗМЕНИТЬ, КОГДА БУДЕТ ГОТОВА РЕГИСТРАЦИЯ
            //return GetSimplePassengers(flightNumber).Count; 
            return 2;
        }
    }
}