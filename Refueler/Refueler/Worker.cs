using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refueler.GscVS;
using MapObject = Refueler.GmcVS.MapObject;
using MapObjectType = Refueler.GmcVS.MapObjectType;

namespace Refueler
{
    public static class Worker
    {
        private static readonly MapObject Garage;
        private const string ComponentName = "Refueler";

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
        }

        public static void FillPlane(MapObject serviceZone, int litersOfFuel, ServiceTaskId taskId)
        {
            Logger.SendMessage(0, ComponentName,
                String.Format("Получено задание: заправить самолет на площадке номер {0} на {1} литров", serviceZone.Number, litersOfFuel));

            var cars = new List<Car>();
            var tasks = new List<Task>();

            while (litersOfFuel > 0) //генерируем машин столько, сколько требуется для доставки топлива на борт
            {
                var car = new Car();
                cars.Add(car);

                var t = new Task(() =>
                {
                    car.GoTo(Garage, serviceZone);
                    SpecialThead.Sleep(50000);
                    Logger.SendMessage(1, ComponentName,
                        String.Format("Самолет на площадке {0} заправлен/дозаправлен на {1} литров", serviceZone.Number, car.Capacity));

                });
                t.Start();
                tasks.Add(t);

                

                litersOfFuel -= car.Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            Logger.SendMessage(0, ComponentName,
                String.Format("Выполнено задание: заправить самолет на площадке номер {0}", serviceZone.Number));


            new GSC().Done(taskId);//сообщаем Управлению Наземным Обслуживанием, что задание выполнено

            Logger.SendMessage(0, ComponentName,
                String.Format("Машины возвращаются в гараж с площадки номер {0}", serviceZone.Number));

            foreach (var car in cars)
            {
                var t = new Task(() => car.GoTo(serviceZone, Garage));
                t.Start();
            }
        }
    }
}