﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Refueler.GscVS;
using MapObject = Refueler.GmcVS.MapObject;
using MapObjectType = Refueler.GmcVS.MapObjectType;

namespace Refueler
{
    public static class Worker
    {
        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
        }

        public static void FillPlane(MapObject serviceZone, int litersOfFuel, ServiceTaskId taskId)
        {
            var cars = new List<Car>();
            var tasks = new List<Task>();

            while (litersOfFuel > 0) //генерируем машин столько, сколько требуется для доставки топлива на борт
            {
                var car = new Car();
                cars.Add(car);

                var t = new Task(() => car.GoTo(Garage, serviceZone));
                t.Start();
                tasks.Add(t);

                litersOfFuel -= car.Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            new GSC().Done(taskId);//сообщаем Управлению Наземным Обслуживанием, что задание выполнено

            foreach (var car in cars)
            {
                var t = new Task(() => car.GoTo(serviceZone, Garage));
                t.Start();
            }
        }
    }
}