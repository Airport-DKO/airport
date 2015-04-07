using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VIPShuttle.AircraftgeneratorVS;
using VIPShuttle.GscVS;
using MapObject = VIPShuttle.GmcVS.MapObject;
using MapObjectType = VIPShuttle.GmcVS.MapObjectType;

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

        public static void ToAirport(MapObject serviceZone, int countOfPassengers, ServiceTaskId taskId)
        {
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
                    new AircraftGenerator().UnloadPassengers(serviceZone, 1);//забираем пассажира у Генератора Самолетов
                    car.GoTo(serviceZone, Airport);
                });
                t.Start();

                //храним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшихся пассажиров
                countOfPassengers--;
            }

            //ожидаем выполнения заданий
            Task.WaitAll(tasks.ToArray());

            new GSC().Done(taskId);//сообщаем Управлению Наземным Обслуживанием, что задание выполнено

            foreach (var car in cars)
            {
                //возвращаем машины в гараж
                var t = new Task(() => car.GoTo(Airport, Garage));
                t.Start();
            }
        }

        public static void ToPlain(MapObject serviceZone, Guid flightNumber, ServiceTaskId taskId)
        {
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
                    new AircraftGenerator().LoadPassengers(serviceZone, (new List<Guid> {passengers[i]}).ToArray());//сажаем пассажира в Генератор Самолетов 
                });
                t.Start();
                tasks.Add(t);

            }

            Task.WaitAll(tasks.ToArray());

            new GSC().Done(taskId);//сообщаем Управлению Наземным Обслуживанием, что задание выполнено

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
            //TODO: запросить пассажиров у Регистрации return GetVips(flightNumber); 
            return new List<Guid>();
        }
    }
}