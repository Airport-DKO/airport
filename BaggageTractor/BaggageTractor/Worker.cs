using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BaggageTractor.GmcVS;

namespace BaggageTractor
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

        public static void ToAirport(MapObject place, int weightOfBaggage, int taskId)
        {
            var cars = new List<Car>();
            var tasks = new List<Task>();

            while (weightOfBaggage > 0)
            {
                var car = new Car();
                cars.Add(car);

                var t = new Task(() => { car.GoTo(Garage, Airport); car.GoTo(Airport,place); });
                t.Start();
                tasks.Add(t);

                weightOfBaggage -= car.Capacity;
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

        public static int GetWeightOfBaggage(int flightNumber)
        {
            //TODO: ЗАПРОСИТЬ У РЕГИСТРАЦИИ
            return 150;
        }


        public static void ToPlain(MapObject place, int flightNumber, int taskId)
        {
            var cars = new List<Car>();
            var tasks = new List<Task>();

            var weightOfBaggage = GetWeightOfBaggage(flightNumber);

            while (weightOfBaggage > 0)
            {
                var car = new Car();
                cars.Add(car);

                var t = new Task(() => { car.GoTo(Garage, Airport); car.GoTo(Airport, place); });
                t.Start();
                tasks.Add(t);

                weightOfBaggage -= car.Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            //TODO: ПЕРЕДАТЬ БАГАЖ ГС
            //TODO: РАССКОМЕНТИТЬ, КОГДА БУДЕТ УНО
            //Done(taskId);

            foreach (var car in cars)
            {
                var t = new Task(() => car.GoTo(place, Garage));
                t.Start();
            }
        }
    }
}