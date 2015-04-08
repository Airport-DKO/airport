using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaggageTractor.AircraftGeneratorVS;
using BaggageTractor.CheckinVS;
using BaggageTractor.GscVS;
using MapObject = BaggageTractor.GmcVS.MapObject;
using MapObjectType = BaggageTractor.GmcVS.MapObjectType;

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

        /// <summary>
        /// Метод, который служит для выгрузки багажа с рейса
        /// </summary>
        /// <param name="serviseZone">Площадка, на которой стоит самолет</param>
        /// <param name="weightOfBaggage">Количество багажа для выгрузки</param>
        /// <param name="taskId">Номер задания</param>
        /// <returns></returns>
        public static void FromPlane(MapObject serviseZone, int weightOfBaggage, ServiceTaskId taskId)
        {
            var cars = new List<Car>();
            var tasks = new List<Task>();

            while (weightOfBaggage > 0) //генерируем столько машинок, сколько нам нужно, чтоб увезти багаж
            {
                //сохраняем коллекцию машинок, чтоб потом их можно было вернуть в гараж
                var car = new Car();
                cars.Add(car); 

                //запускаем для каждой машинки асинхронно задание "езжай к самолету(чтоб забрать багаж), затем езжай в аэропорт(чтоб доставить багаж)"
                var t = new Task(() =>
                {
                    car.GoTo(Garage, serviseZone);
                    new AircraftGenerator().UnloadBaggage(serviseZone, weightOfBaggage);//забираем багаж у Генератора Самолетов
                    car.GoTo(serviseZone, Airport);
                });
                t.Start();

                //храним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшегося багажа(считаем, что машинка, сгенерированная на этой итерации, увезла столько, сколько смогла погрузить)
                weightOfBaggage -= car.Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            new GSC().Done(taskId);//сообщаем Управлению Наземным Обслуживанием, что задание выполнено 

            foreach (var car in cars)
            {
                //возвращаем машинки в гараж
                var t = new Task(() => car.GoTo(serviseZone, Garage));
                t.Start();
            }
        }

        /// <summary>
        /// Метод, который служит для загрузки багажа на рейс
        /// </summary>
        /// <param name="serviseZone">площадка, на которой стоит самолет</param>
        /// <param name="flightNumber">номер рейса, багаж пассажиров которого следует погрузить</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        public static void ToPlain(MapObject serviseZone, Guid flightNumber, ServiceTaskId taskId)
        {
            var cars = new List<Car>();
            var tasks = new List<Task>();

            //узнаем вес багажа
            var weightOfBaggage = GetWeightOfBaggage(flightNumber);

            while (weightOfBaggage > 0) //генерируем столько машинок, сколько нам нужно, чтоб увезти багаж
            {
                //сохраняем коллекцию машинок, чтоб потом их можно было вернуть в гараж
                var car = new Car();
                cars.Add(car);

                //запускаем для каждой машинки асинхронно задание "езжай в аэропорт(чтоб забрать багаж), затем езжай к самолету(чтоб доставить багаж)"
                var t = new Task(() =>
                {
                    car.GoTo(Garage, Airport);
                    car.GoTo(Airport, serviseZone);
                    new AircraftGenerator().LoadBaggage(serviseZone, weightOfBaggage);//загружаем багаж в Генератору Самолетов
                });
                t.Start();

                //краним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшегося багажа(считаем, что машинка, сгенерированная на этой итерации, увезла столько, сколько смогла погрузить)
                weightOfBaggage -= car.Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            new GSC().Done(taskId); //cообщаем Управлению Наземным Обслуживанием, что задание выполнено

            foreach (var car in cars)
            {
                //возвращаем машинки в гараж
                var t = new Task(() => car.GoTo(serviseZone, Garage));
                t.Start();
            }
        }

        /// <summary>
        /// Метод, который запрашивает количество багажа
        /// </summary>
        /// <param name="flightNumber">номер рейса, о багаже пассажиров которого необходимо получить информацию</param>
        /// <returns></returns>
        public static int GetWeightOfBaggage(Guid flightNumber)
        {
            new WebServiceCheckIn().GetBaggage(flightNumber); //запрашиваем вес у Регистрации
            return 150;
        }
    }
}