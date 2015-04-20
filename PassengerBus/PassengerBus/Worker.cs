using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PassengerBus.AircraftgeneratorVS;
using PassengerBus.CheckInVS;
using PassengerBus.GscVS;
using MapObject = PassengerBus.GmcVS.MapObject;
using MapObjectType = PassengerBus.GmcVS.MapObjectType;

namespace PassengerBus
{
    public static class Worker
    {
        private static readonly MapObject Garage;
        private static readonly MapObject Airport;
        private const string ComponentName = "PassengerBus";

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
            Airport = new MapObject { MapObjectType = MapObjectType.Airport };
        }

        /// <summary>
        /// Метод, который служит для перемещения пассажиров с самолета в аэропорт
        /// </summary>
        /// <param name="serviceZone">площадка, на которой стоит самолет</param>
        /// <param name="countOfPassengers">количество пассажиров для выгрузки</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        public static void ToAirport(MapObject serviceZone, int countOfPassengers, ServiceTaskId taskId)
        {
            Logger.SendMessage(0, ComponentName, 
                String.Format("Задание получено: забрать {1} пассажиров эконом-класса с борта на площадке номер {0}", serviceZone.Number, countOfPassengers));

            var buses = new List<Bus>();
            var tasks = new List<Task>();

            while (countOfPassengers > 0) //генерируем столько автобусов, сколько нам нужно, чтоб увезти пассажиров
            {
                //сохраняем коллекцию автобусов, чтоб потом их можно было вернуть в гараж
                var bus = new Bus();
                buses.Add(bus);

                //запускаем для каждой машинки асинхронно задание "езжай к самолету(чтоб забрать пассажиров), затем езжай в аэропорт(чтоб доставить пассажиров)"
                var t = new Task(() =>
                {
                    bus.GoTo(Garage, serviceZone);
                    new AircraftGenerator().UnloadStandartPassengers(serviceZone, bus.Capacity);  //забираем пассажиров у Генератора Самолетов 
                    bus.GoTo(serviceZone, Airport);
                    Logger.SendMessage(1, ComponentName,
                        String.Format("{1} или меньше(остаток) пассажиров вывезено с борта на площадке {0}", serviceZone.Number, bus.Capacity));
                });
                t.Start();

                //храним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшихся пассажиров(автобус увез сколько смог)
                countOfPassengers -= bus.Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            Logger.SendMessage(0, ComponentName, 
                String.Format("Задание выполнено: забрать пассажиров с борта на площадке номер {0}", serviceZone.Number));

            new GSC().Done(taskId); //сообщаем Управлению Наземным Обслуживанием, что задание выполнено

            Logger.SendMessage(0, ComponentName, 
                String.Format("Автобусы возвращаются от аэропорта в гараж"));

            foreach (var bus in buses)
            {
                //возвращаем автобусы в гараж
                Bus localCopyOfBus = bus;
                var t = new Task(() => localCopyOfBus.GoTo(Airport, Garage));
                t.Start();
            }
        }

        /// <summary>
        /// Метод, который служит для перемещения пассажиров из аэропорта на самолет, изменяет свойства пассажиров
        /// </summary>
        /// <param name="serviceZone">площадка, на которой стоит самолет</param>
        /// <param name="flightNumber">номер рейса</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        public static void ToPlain(MapObject serviceZone, Guid flightNumber, ServiceTaskId taskId)
        {
            Logger.SendMessage(0, ComponentName, 
                String.Format("Задание получено: доставить пассажиров на борт на площадке номер {0}", serviceZone.Number));

            var passengers = GetPassengers(flightNumber);


            var buses = new List<Bus>();
            var tasks = new List<Task>();

            while (passengers.Count > 0) //генерируем столько автобусов, сколько нам нужно, чтоб увезти пассажиров
            {
                //сохраняем коллекцию автобусов, чтоб потом их можно было вернуть в гараж
                var bus = new Bus();
                buses.Add(bus);

                var passengersCount = passengers.Count >= 100 ? 100 : passengers.Count;
                var passengersForBus = passengers.GetRange(0, passengersCount);
                passengers.RemoveRange(0,passengersCount);

                //запускаем для каждой машинки асинхронно задание "езжай к самолету(чтоб забрать пассажиров), затем езжай в аэропорт(чтоб доставить пассажиров)"

                var t = new Task(() =>
                {
                    var localCopyOfPassengers = passengersForBus;
                    bus.GoTo(Garage, Airport);
                    bus.GoTo(Airport, serviceZone);
                    new AircraftGenerator().LoadStandartPassengers(serviceZone,
                        localCopyOfPassengers.ToArray()); //загружаем пассажиров в Генератору Самолетов 
                    SpecialThead.Sleep(50000);//изображаем деятельность
                    Logger.SendMessage(1, ComponentName,
                        String.Format("{1} или меньше(остаток) пассажиров доставлено на борт на площадке {0}", serviceZone.Number, bus.Capacity));
                });
                t.Start();

                //храним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);
            }

            //ждем, когда все пассажиры будут поставлены на самолет(все розданные таски выполнятся)
            Task.WaitAll(tasks.ToArray());

            Logger.SendMessage(0, ComponentName, String.Format("Задание выполнено: доставить пассажиров на борт на площадке номер {0}", serviceZone.Number));

            new GSC().Done(taskId); //сообщаем Управлению Наземным Обслуживанием, что задание выполнено

            Logger.SendMessage(0, ComponentName, String.Format("Автобусы возвращаются с площадки номер {0} в гараж", serviceZone.Number));

            foreach (var bus in buses)
            {
                //возвращаем автобусы в гараж
                Bus localCopyOfBus = bus;
                var t = new Task(() => localCopyOfBus.GoTo(Airport, Garage));
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
            var passengers = new WebServiceCheckIn().GetSimplePassengers(flightNumber).ToList(); //запросить пассажиров у Регистрации
            Logger.SendMessage(1, ComponentName, String.Format("Получена информация, что на рейс {0} зарегистрированно {1} пассажиров эконом-класса", flightNumber, passengers.Count));
            return passengers;
        }
    }
}