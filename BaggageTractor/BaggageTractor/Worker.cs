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
        public const string ComponentName = "BaggageTractor";

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
            Airport = new MapObject { MapObjectType = MapObjectType.Airport };
        }

        /// <summary>
        /// Метод, который служит для выгрузки багажа с рейса
        /// </summary>
        /// <param name="serviceZone">Площадка, на которой стоит самолет</param>
        /// <param name="weightOfBaggage">Количество багажа для выгрузки</param>
        /// <param name="taskId">Номер задания</param>
        /// <returns></returns>
        public static void FromPlane(MapObject serviceZone, int weightOfBaggage, ServiceTaskId taskId)
        {
            Logger.SendMessage(0, ComponentName, String.Format("Задание получено: забрать {1} кг багажа с борта на площадке номер {0}", serviceZone.Number, weightOfBaggage));

            #region new version
            var cars = new List<Car>();
            var tasks = new List<Task>();
            while (weightOfBaggage > 0 && cars.Count<3) //генерируем столько машинок, сколько нам нужно, чтоб увезти багаж
            {                                           //но не больше трех - хотелка Чапкина
                //сохраняем коллекцию машинок, чтоб потом их можно было вернуть в гараж
                var car = new Car();
                cars.Add(car);

                //запускаем для каждой машинки асинхронно задание "езжай к самолету(чтоб забрать багаж), затем езжай в аэропорт(чтоб доставить багаж)"
                var t = new Task(() =>
                {
                    car.GoTo(Garage, serviceZone);
                    SpecialThead.Sleep(50000);//изображаем деятельность
                    new AircraftGenerator().UnloadBaggage(serviceZone, car.Capacity);//забираем багаж у Генератора Самолетов
                    car.GoTo(serviceZone, Airport);
                    Logger.SendMessage(1, ComponentName,
                        String.Format("{1} или меньше(остаток) килограмм багажа вывезено с борта на площадке {0}.", serviceZone.Number, car.Capacity));
                });
                t.Start();

                //храним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшегося багажа(считаем, что машинка, сгенерированная на этой итерации, увезла столько, сколько смогла погрузить)
                weightOfBaggage -= car.Capacity;
            }

            while (weightOfBaggage > 0)
            {
                int indexOfFreeCar = Task.WaitAny(tasks.ToArray());
                tasks[indexOfFreeCar] = new Task(() =>
                {
                    cars[indexOfFreeCar].GoTo(Airport, serviceZone);
                    SpecialThead.Sleep(50000);//изображаем деятельность
                    new AircraftGenerator().UnloadBaggage(serviceZone, cars[indexOfFreeCar].Capacity);//забираем багаж у Генератора Самолетов
                    cars[indexOfFreeCar].GoTo(serviceZone, Airport);
                    Logger.SendMessage(1, ComponentName,
                        String.Format("{1} или меньше(остаток) килограмм багажа вывезено с борта на площадке {0}.", serviceZone.Number, cars[indexOfFreeCar].Capacity));
                });
                tasks[indexOfFreeCar].Start();
                weightOfBaggage -= cars[indexOfFreeCar].Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            #endregion


            #region old version
            /*
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
                    car.GoTo(Garage, serviceZone);
                    new AircraftGenerator().UnloadBaggage(serviceZone, car.Capacity);//забираем багаж у Генератора Самолетов
                    car.GoTo(serviceZone, Airport);
                    Logger.SendMessage(1, ComponentName,
                        String.Format("{1} или меньше(остаток) килограмм багажа вывезено с борта на площадке {0}.", serviceZone.Number, car.Capacity));
                });
                t.Start();

                //храним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшегося багажа(считаем, что машинка, сгенерированная на этой итерации, увезла столько, сколько смогла погрузить)
                weightOfBaggage -= car.Capacity;
            }

            Task.WaitAll(tasks.ToArray());*/
            #endregion



            Logger.SendMessage(0, ComponentName, String.Format("Задание выполнено: забрать багаж с борта на площадке номер {0}.", serviceZone.Number));

            new GSC().Done(taskId);//сообщаем Управлению Наземным Обслуживанием, что задание выполнено 

            Logger.SendMessage(0, ComponentName, String.Format("Машины возвращаются в гараж.", serviceZone.Number));

            foreach (var car in cars)
            {
                //возвращаем машинки в гараж
                var t = new Task(() => car.GoTo(Airport, Garage));
                t.Start();
            }
        }

        /// <summary>
        /// Метод, который служит для загрузки багажа на рейс
        /// </summary>
        /// <param name="serviceZone">площадка, на которой стоит самолет</param>
        /// <param name="flightNumber">номер рейса, багаж пассажиров которого следует погрузить</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        public static void ToPlain(MapObject serviceZone, Guid flightNumber, ServiceTaskId taskId)
        {
            Logger.SendMessage(0, ComponentName, String.Format("Задание получено: загрузить багаж на борт на площадке номер {0}", serviceZone.Number));

            //узнаем вес багажа
            var weightOfBaggage = GetWeightOfBaggage(flightNumber);

            #region new version
            var cars = new List<Car>();
            var tasks = new List<Task>();
            while (weightOfBaggage > 0 && cars.Count < 3) //генерируем столько машинок, сколько нам нужно, чтоб увезти багаж
            {                                           //но не больше трех - хотелка Чапкина
                //сохраняем коллекцию машинок, чтоб потом их можно было вернуть в гараж
                var car = new Car();
                cars.Add(car);

                //запускаем для каждой машинки асинхронно задание "езжай в аэропорт(чтоб забрать багаж), затем езжай к самолету(чтоб доставить багаж)"
                var t = new Task(() =>
                {
                    car.GoTo(Garage, Airport);
                    SpecialThead.Sleep(10000);//изображаем деятельность
                    car.GoTo(Airport, serviceZone);
                    SpecialThead.Sleep(10000);//изображаем деятельность
                    new AircraftGenerator().LoadBaggage(serviceZone, car.Capacity);//загружаем багаж в Генератору Самолетов
                    Logger.SendMessage(1, ComponentName,
                        String.Format("{1} или меньше(остаток) килограмм багажа погружено на борт на площадке {0}.", serviceZone.Number, car.Capacity));
                });
                t.Start();
                tasks.Add(t); //храним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение

                //уменьшаем количество оставшегося багажа(считаем, что машинка, сгенерированная на этой итерации, увезла столько, сколько смогла погрузить)
                weightOfBaggage -= car.Capacity;
            }

            while (weightOfBaggage > 0)
            {
                int indexOfFreeCar = Task.WaitAny(tasks.ToArray());
                tasks[indexOfFreeCar] = new Task(() =>
                {
                    cars[indexOfFreeCar].GoTo(serviceZone, Airport);
                    SpecialThead.Sleep(10000);//изображаем деятельность
                    cars[indexOfFreeCar].GoTo(Airport, serviceZone);
                    SpecialThead.Sleep(10000);//изображаем деятельность
                    new AircraftGenerator().LoadBaggage(serviceZone, cars[indexOfFreeCar].Capacity);//загружаем багаж в Генератору Самолетов
                    Logger.SendMessage(1, ComponentName,
                        String.Format("{1} или меньше(остаток) килограмм багажа погружено на борт на площадке {0}.", serviceZone.Number, cars[indexOfFreeCar].Capacity));
                });
                tasks[indexOfFreeCar].Start();
                weightOfBaggage -= cars[indexOfFreeCar].Capacity;
            }

            Task.WaitAll(tasks.ToArray());
            #endregion

            #region old version
            /*
            var cars = new List<Car>();
            var tasks = new List<Task>();
            
            while (weightOfBaggage > 0) //генерируем столько машинок, сколько нам нужно, чтоб увезти багаж
            {
                //сохраняем коллекцию машинок, чтоб потом их можно было вернуть в гараж
                var car = new Car();
                cars.Add(car);

                //запускаем для каждой машинки асинхронно задание "езжай в аэропорт(чтоб забрать багаж), затем езжай к самолету(чтоб доставить багаж)"
                var t = new Task(() =>
                {
                    car.GoTo(Garage, Airport);
                    car.GoTo(Airport, serviceZone);
                    new AircraftGenerator().LoadBaggage(serviceZone, car.Capacity);//загружаем багаж в Генератору Самолетов
                    SpecialThead.Sleep(50000);//изображаем деятельность
                    Logger.SendMessage(1, ComponentName,
                        String.Format("{1} или меньше(остаток) килограмм багажа погружено на борт на площадке {0}.", serviceZone.Number, car.Capacity));
                });
                t.Start();

                //краним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшегося багажа(считаем, что машинка, сгенерированная на этой итерации, увезла столько, сколько смогла погрузить)
                weightOfBaggage -= car.Capacity;
            }

            Task.WaitAll(tasks.ToArray());*/
            #endregion

            Logger.SendMessage(0, ComponentName, String.Format("Задание выполнено: загрузить багаж на борт на площадке номер {0}", serviceZone.Number));

            new GSC().Done(taskId); //cообщаем Управлению Наземным Обслуживанием, что задание выполнено

            Logger.SendMessage(0, ComponentName, String.Format("Машины возвращаются с площадки номер {0} в гараж.", serviceZone.Number));

            foreach (var car in cars)
            {
                //возвращаем машинки в гараж
                var t = new Task(() => car.GoTo(serviceZone, Garage));
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
            var weightOfBaggage = new WebServiceCheckIn().GetBaggage(flightNumber); //запрашиваем вес у Регистрации
            Logger.SendMessage(1, ComponentName, String.Format("Получена информация, что на рейс {0} зарегистрированно {1} кг багажа.", flightNumber, weightOfBaggage));
            return weightOfBaggage;
        }
    }
}