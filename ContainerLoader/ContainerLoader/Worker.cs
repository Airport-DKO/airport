using System;
using System.Collections.Generic;
using ContainerLoader.CheckinVS;
using ContainerLoader.GscVS;
using MapObject = ContainerLoader.GmcVS.MapObject;
using MapObjectType = ContainerLoader.GmcVS.MapObjectType;

namespace ContainerLoader
{
    public static class Worker
    {
        private const string ComponentName = "ContainerLoader";
        private static List<Tuple<Guid, MapObject>> WhoWhere; //список, чтоб запоминать, где какой погрузчик находится (используется для возврата в гараж)
        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject {MapObjectType = MapObjectType.Garage};
            WhoWhere = new List<Tuple<Guid, MapObject>>();
        }

        /// <summary>
        /// Метод, который вызывает погрузчик багажа на площадку обслуживания самолета
        /// </summary>
        /// <param name="serviceZone">площадка, на которой находится обслуживаемый самолет</param>
        /// <param name="flightNumber">номер рейса</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        public static void GoToServiceZone(MapObject serviceZone, Guid flightNumber, ServiceTaskId taskId)
        {
            Logger.SendMessage(0, ComponentName, String.Format("Задание получено: подогнать погрузчик багажа на площадку номер {0}", serviceZone.Number));

//            var countOfBaggage = new WebServiceCheckIn().GetBaggage(flightNumber);
//            Logger.SendMessage(0, ComponentName, String.Format("Получена информация о {0} кг багажа на рейс номер {1}", countOfBaggage, flightNumber));
//            if (countOfBaggage > 0) //если багаж вообще есть, что-то делаем
//            {
//                Logger.SendMessage(0, ComponentName, String.Format("Погрузчик багажа выехал на площадку обслуживания номер {0}", serviceZone.Number));

                var car = new Car();
                car.GoTo(Garage, serviceZone);

                Logger.SendMessage(1, ComponentName, String.Format("Погрузчик багажа прибыл на площадку обслуживания номер {0}", serviceZone.Number));

                WhoWhere.Add(new Tuple<Guid, MapObject>(car.Id, serviceZone)); //запоминаем, что на этой площадке находится погрузчик с некоторым идентификатором
//            } //если нет багажа, считаем, что все сделано

            Logger.SendMessage(0, ComponentName, 
                String.Format("Задание выполнено: подогнать погрузчик багажа на площадку номер {0}", serviceZone.Number));

            new GSC().Done(taskId); //сообщаем Управлению Наземным Обслуживанием, что задание выполнено
        }

        /// <summary>
        /// Метод, который отправляет погрузчик багажа в гараж, когда тот становится не нужен на площадке
        /// </summary>
        /// <param name="serviceZone">площадка, на которой находится обслуженный самолет и, соответственно, сам погрузчик багажа</param>
        /// <returns></returns>
        public static void GoToGarage(MapObject serviceZone)
        {
            Logger.SendMessage(0, ComponentName, String.Format("Задание получено: вернуть погрузчик багажа с площадки номер {0} в гараж", serviceZone.Number));

            //пытаемся найти машину на стоянке в списке и достать ее id
            Guid id = Guid.Empty;
            foreach (var tuple in WhoWhere)
            {
                if (tuple.Item2 == serviceZone)
                {
                    id = tuple.Item1;
                    break;
                }
            }

            if (id == Guid.Empty)
            {
                Logger.SendMessage(0, ComponentName, String.Format("Погрузчик не найден на площадке. Задание считается выполненым", serviceZone.Number));
                return;
            }

            //если была - создаем с тем же айди
            Car car = new Car(id);

            //удаляем машину из списка 
            WhoWhere.Remove(new Tuple<Guid, MapObject>(id, serviceZone));

            Logger.SendMessage(0, ComponentName, String.Format("Погрузчик багажа выехал с площадки номер {0} в гараж", serviceZone.Number));

            //возвращаем машину в гараж
            car.GoTo(serviceZone, Garage);

            Logger.SendMessage(1, ComponentName, String.Format("Погрузчик вернулся с площадки номер {0} в гараж", serviceZone.Number));
        }
    }
}