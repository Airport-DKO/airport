using System.Collections.Generic;
using System.Threading.Tasks;
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

        /// <summary>
        /// Метод, который служит для выгрузки багажа с рейса
        /// </summary>
        /// <param name="serviseZone">Площадка, на которой стоит самолет</param>
        /// <param name="weightOfBaggage">Количество багажа для выгрузки</param>
        /// <param name="taskId">Номер задания</param>
        /// <returns></returns>
        public static void FromPlane(MapObject serviseZone, int weightOfBaggage, int taskId)
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
                    //TODO: забираем багаж у Генератора Самолетов UnloadBaggage(serviseZone,weightOfBaggage);
                    car.GoTo(serviseZone, Airport);
                });
                t.Start();

                //краним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшегося багажа(считаем, что машинка, сгенерированная на этой итерации, увезла столько, сколько смогла погрузить)
                weightOfBaggage -= car.Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            //TODO: сообщаем Управлению Наземным Обслуживанием, что задание выполнено Done(taskId);

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
        public static void ToPlain(MapObject serviseZone, int flightNumber, int taskId)
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
                    //TODO: загружаем багаж у Генератору Самолетов LoadBaggage(serviseZone,weightOfBaggage);
                });
                t.Start();

                //краним коллекцию тасков, чтоб в дальнейшем отслеживать их выполнение
                tasks.Add(t);

                //уменьшаем количество оставшегося багажа(считаем, что машинка, сгенерированная на этой итерации, увезла столько, сколько смогла погрузить)
                weightOfBaggage -= car.Capacity;
            }

            Task.WaitAll(tasks.ToArray());

            //TODO: сообщаем Управлению Наземным Обслуживанием, что задание выполнено Done(taskId);

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
        public static int GetWeightOfBaggage(int flightNumber)
        {
            //TODO: запрашиваем вес у Регистрации GetBaggage(flightNumber)
            return 150;
        }
    }
}