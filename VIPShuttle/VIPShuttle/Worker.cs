using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIPShuttle.AircraftgeneratorVS;
using VIPShuttle.CheckinVS;
using VIPShuttle.GscVS;
using MapObject = VIPShuttle.GmcVS.MapObject;
using MapObjectType = VIPShuttle.GmcVS.MapObjectType;

namespace VIPShuttle
{
    public static class Worker
    {
        private static readonly MapObject Garage;
        private static readonly MapObject Airport;
        private const string ComponentName = "VIPShuttle";

        static Worker()
        {
            Garage = new MapObject {MapObjectType = MapObjectType.Garage};
            Airport = new MapObject {MapObjectType = MapObjectType.Airport};
        }

        public static void ToAirport(MapObject serviceZone, int countOfPassengers, ServiceTaskId taskId)
        {
            Logger.SendMessage(0, ComponentName,
                String.Format("Задание получено: забрать {1} пассажиров VIP-класса с борта на площадке номер {0}", serviceZone.Number, countOfPassengers));

            var cars = new List<Car>();
            var tasks = new List<Task>();

             while (countOfPassengers > 0) //генерируем столько машин, сколько нам нужно, чтоб увезти пассажиров
            {
                //сохраняем коллекцию машинок, чтоб потом их можно было вернуть в гараж
                var car = new Car();
                cars.Add(car);

                //запускаем для каждой машинки асинхронно задание "езжай к самолету(чтоб забрать пассажира), затем езжай в аэропорт(чтоб доставить пассажира)"
                var t = new Task(() =>
                {
                    car.GoTo(Garage, serviceZone);
                    new AircraftGenerator().UnloadVipPassengers(serviceZone, 1);//забираем пассажира у Генератора Самолетов
                    car.GoTo(serviceZone, Airport);
                    Logger.SendMessage(1, ComponentName,
                       String.Format("1 пассажир вывезен с борта на площадке {0}", serviceZone.Number));
                
                });
                t.Start();

                //храним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшихся пассажиров
                countOfPassengers--;
            }

            //ожидаем выполнения заданий
            Task.WaitAll(tasks.ToArray());

            Logger.SendMessage(0, ComponentName,
                String.Format("Задание выполнено: забрать пассажиров VIP-класса с борта на площадке номер {0}", serviceZone.Number, countOfPassengers));

            new GSC().Done(taskId);//сообщаем Управлению Наземным Обслуживанием, что задание выполнено

            Logger.SendMessage(0, ComponentName,
                String.Format("Машины возвращаются с площадки номер {0} в гараж", serviceZone.Number));

            foreach (var car in cars)
            {
                //возвращаем машины в гараж
                var t = new Task(() => car.GoTo(Airport, Garage));
                t.Start();
            }
        }

        public static void ToPlain(MapObject serviceZone, Guid flightNumber, ServiceTaskId taskId)
        {
            Logger.SendMessage(0, ComponentName,
                String.Format("Задание получено: доставить пассажиров на борт на площадке номер {0}", serviceZone.Number));

            var passengers = GetPassengers(flightNumber);

            var cars = new List<Car>();
            var tasks = new List<Task>();
            for (int i = 0; i < passengers.Count; i++)
            {
                var car = new Car();
                cars.Add(car);

                var t = new Task(() =>
                {
                    car.GoTo(Garage,Airport);
                    car.GoTo(Airport,serviceZone);
                    new AircraftGenerator().LoadVipPassengers(serviceZone, (new List<Guid> {passengers[i]}).ToArray());//сажаем пассажира в Генератор Самолетов 
                    Logger.SendMessage(1, ComponentName,
                        String.Format("1 пассажир доставлен на борт на площадке {0}.", serviceZone.Number));
                });
                t.Start();
                tasks.Add(t);

            }

            Task.WaitAll(tasks.ToArray());

            Logger.SendMessage(0, ComponentName, String.Format("Задание выполнено: доставить пассажиров на борт на площадке номер {0}", serviceZone.Number));

            new GSC().Done(taskId); //сообщаем Управлению Наземным Обслуживанием, что задание выполнено

            Logger.SendMessage(0, ComponentName, String.Format("Машины возвращаются с площадки номер {0} в гараж.", serviceZone.Number));

            foreach (var car in cars)
            {
                var t = new Task(() => car.GoTo(serviceZone, Garage));
                t.Start();
            }
        }

        /// <summary>
        /// Метод, который позволяет определить количество пассажиров на рейс
        /// </summary>
        /// <param name="flightNumber">номер рейса</param>
        /// <returns></returns>
        public static List<Guid> GetPassengers(Guid flightNumber)
        {
            var countOfPassengers = new WebServiceCheckIn().GetVips(flightNumber).ToList(); //запросить пассажиров у Регистрации
            Logger.SendMessage(1, ComponentName, String.Format("Получена информация, что на рейс {0} зарегистрированно {1} пассажиров VIP-класса.", flightNumber, countOfPassengers));
            return countOfPassengers;
        }
    }
}