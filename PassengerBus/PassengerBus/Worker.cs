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

        /// <summary>
        /// Метод, который служит для перемещения пассажиров с самолета в аэропорт
        /// </summary>
        /// <param name="serviceZone">площадка, на которой стоит самолет</param>
        /// <param name="countOfPassengers">количество пассажиров для выгрузки</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        public static void ToAirport(MapObject serviceZone, int countOfPassengers, int taskId)
        {
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
                    //TODO: забираем пассажиров у Генератора Самолетов UnloadPassengers(serviceZone,countOfPassengers);
                    bus.GoTo(serviceZone, Airport);
                });
                t.Start();

                //храним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшихся пассажиров(автобус увез сколько смог)
                countOfPassengers -= bus.Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            //TODO: сообщаем Управлению Наземным Обслуживанием, что задание выполнено Done(taskId);

            foreach (var bus in buses)
            {
                //возвращаем автобусы в гараж
                var t = new Task(() => bus.GoTo(Airport, Garage));
                t.Start();
            }
        }

        /// <summary>
        /// Метод, который служит для перемещения пассажиров из аэропорта на самолет, изменяет свойства пассажиров
        /// </summary>
        /// <param name="place">площадка, на которой стоит самолет</param>
        /// <param name="flightNumber">номер рейса</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        public static void ToPlain(MapObject place, int flightNumber, int taskId)
        {
            //TODO: узнаем у Регистрации идентификаторы пассажиров var passengers = GetSimplePassengers(flightNumber);
            var passengers = GetPassengers(flightNumber);
            var countOfPassengers = passengers.Count;

            var buses = new List<Bus>();
            var tasks = new List<Task>();

            var busNumber = 0; //сколько автобусов отправили (чтобы вычислять с какого по какой идентификатор пассажира взять для посадки на самолет)
            while (countOfPassengers > 0) //генерируем столько автобусов, сколько нам нужно, чтоб увезти пассажиров
            {
                //сохраняем коллекцию автобусов, чтоб потом их можно было вернуть в гараж
                var bus = new Bus();
                buses.Add(bus);

                //запускаем для каждой машинки асинхронно задание "езжай к самолету(чтоб забрать пассажиров), затем езжай в аэропорт(чтоб доставить пассажиров)"
                var t = new Task(() =>
                {
                    bus.GoTo(Garage, Airport);
                    bus.GoTo(Airport, place);
                    //TODO: загружаем пассажиров в Генератору Самолетов LoadPassengers(serviceZone,passengers.GetRange(busNumber * bus.Capacity, bus.Capacity));
                });
                t.Start();

                //храним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшихся пассажиров(автобус увез сколько смог)
                countOfPassengers -= bus.Capacity;

                //считаем количество отправленных сообщений
                busNumber++;
            }

            //ждем, когда все пассажиры будут поставлены на самолет(все розданные таски выполнятся)
            Task.WaitAll(tasks.ToArray());

            //TODO: сообщаем Управлению Наземным Обслуживанием, что задание выполнено Done(taskId);

            foreach (var bus in buses)
            {
                //возвращаем автобусы в гараж
                var t = new Task(() => bus.GoTo(Airport, Garage));
                t.Start();
            }
        }

        /// <summary>
        /// Метод, который позволяет определить количество пассажиров на рейс
        /// </summary>
        /// <param name="flightNumber">номер рейса</param>
        /// <returns></returns>
        public static List<Guid> GetPassengers(int flightNumber)
        {
            //TODO: запросить пассажиров у Регистрации return GetSimplePassengers(flightNumber); 
            return new List<Guid>();
        }
    }
}