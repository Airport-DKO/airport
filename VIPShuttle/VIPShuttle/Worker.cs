using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VIPShuttle.GmcVS;

namespace VIPShuttle
{
    public static class Worker
    {
        private static readonly MapObject Garage;
        private static readonly MapObject Airport;

        static Worker()
        {
            Garage = new MapObject {MapObjectType = MapObjectType.Garage};

            Airport = new MapObject {MapObjectType = MapObjectType.Airport};
        }

        public static void ToAirport(MapObject place, int countOfPassengers, int taskId)
        {
            var cars = new List<Car>();
            var tasks = new List<Task>();
            for (int i = 0; i < countOfPassengers; i++)
            {
                var car = new Car();
                cars.Add(car);

                var t = new Task(() => car.CarryPassenger(Garage, place, Airport));
                t.Start();
                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());

            //TODO: РАССКОМЕНТИТЬ, КОГДА БУДЕТ УНО
            //Done(taskId);

            foreach (var car in cars)
            {
                var t = new Task(() => car.GoTo(Airport, Garage));
                t.Start();
            }
        }

        public static void ToPlain(MapObject place, int flightNumber, int taskId)
        {
            //TODO: ИЗМЕНИТЬ, КОГДА БУДЕТ ГОТОВА РЕГИСТРАЦИЯ
            //var passengers = GetVips(flightNumber);
            var passengers = new List<Guid>();

            var cars = new List<Car>();
            var tasks = new List<Task>();
            for (int i = 0; i < passengers.Count; i++)
            {
                var car = new Car();
                cars.Add(car);

                var t = new Task(() => car.CarryPassenger(Garage, Airport, place, passengers[i]));
                t.Start();
                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());

            //TODO: РАССКОМЕНТИТЬ, КОГДА БУДЕТ УНО
            //Done(taskId);

            foreach (var car in cars)
            {
                var t = new Task(() => car.GoTo(place, Garage));
                t.Start();
            }
        }

        public static int GetPassengersCount(int flightNumber)
        {
            //TODO: ИЗМЕНИТЬ, КОГДА БУДЕТ ГОТОВА РЕГИСТРАЦИЯ
            //return GetVips(flightNumber).Count; 
            return 2;
        }
    }
}