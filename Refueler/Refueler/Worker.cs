using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Refueler.GmcVS;

namespace Refueler
{
    public static class Worker
    {
        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
        }

        public static void FillPlane(MapObject place, int litersOfFuel, int taskId)
        {
            var cars = new List<Car>();
            var tasks = new List<Task>();

            while (litersOfFuel > 0)
            {
                var car = new Car();
                cars.Add(car);

                var t = new Task(() => car.GoTo(Garage, place));
                t.Start();
                tasks.Add(t);

                litersOfFuel -= car.Capacity;
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
    }
}