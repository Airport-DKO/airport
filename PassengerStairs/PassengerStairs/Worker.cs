using System;
using System.Collections.Generic;
using PassengerStairs.CheckinVS;
using PassengerStairs.GscVS;
using MapObject = PassengerStairs.GmcVS.MapObject;
using MapObjectType = PassengerStairs.GmcVS.MapObjectType;

namespace PassengerStairs
{
    public static class Worker
    {
        private static readonly string ComponentName;

        private static SynchronizedCollection<Tuple<Guid, MapObject>> WhoWhere; //список, чтоб запоминать, где какой трап находится (используется для возврата в гараж)

        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
            WhoWhere = new SynchronizedCollection<Tuple<Guid, MapObject>>();
            ComponentName = "PassengerStairs";
        }



        /// <summary>
        /// Метод, который вызывает трап на площадку обслуживания самолета
        /// </summary>
        /// <param name="serviceZone">площадка, на которой находится обслуживаемый самолет</param>
        /// <param name="flightNumber">номер рейса</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        public static void GoToServiceZone(MapObject serviceZone, Guid flightNumber, ServiceTaskId taskId)
        {
            Logger.SendMessage(0, ComponentName, String.Format("Задание получено: подогнать трап на площадку номер {0}", serviceZone.Number));

            var passangersCount =
                new WebServiceCheckIn().GetSimplePassengers(flightNumber).Length +
                new WebServiceCheckIn().GetVips(flightNumber).Length;

            Logger.SendMessage(0, ComponentName, String.Format("Получено {0} пассажиров на рейс номер {1}", passangersCount, flightNumber));

            if (passangersCount >= 0) //если пассажиры есть - что-то делаем !!!
            {//TODO исправить условие с >= на >
                Logger.SendMessage(0, ComponentName, String.Format("Трап выехал на площадку обслуживания номер {0}", serviceZone.Number));

                var car = new Car();
                car.GoTo(Garage, serviceZone);

                Logger.SendMessage(1, ComponentName, String.Format("Трап прибыл на площадку обслуживания номер {0}", serviceZone.Number));

                WhoWhere.Add(new Tuple<Guid, MapObject>(car.Id, serviceZone)); //запоминаем, что на этой площадке находится погрузчик с некоторым идентификатором
            } //если пассажиров нет - считаем, что все сделано

            Logger.SendMessage(0, ComponentName, String.Format("Задание выполнено: подогнать трап на площадку номер {0}", serviceZone.Number));

            new GSC().Done(taskId); //сообщаем Управлению Наземным Обслуживанием, что задание выполнено
        }

        /// <summary>
        /// Метод, который отправляет трап в гараж, когда тот становится не нужен на площадке
        /// </summary>
        /// <param name="serviceZone">площадка, на которой находится обслуженный самолет и, соответственно, сам погрузчик багажа</param>
        /// <returns></returns>
        public static void GoToGarage(MapObject serviceZone)
        {
            Logger.SendMessage(0, ComponentName, String.Format("Задание получено: вернуть трап с площадки номер {0} в гараж.", serviceZone.Number));

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

            //если машины на площадке нет - ничего не делаем
            if (id == Guid.Empty)
            {
                Logger.SendMessage(0, ComponentName, String.Format("Трап не найден на площадке. Задание считается выполненым.", serviceZone.Number));
                return;
            }

            //создаем машину со старым id
            Car car = new Car(id);

            //удаляем машину из списка 
            WhoWhere.Remove(new Tuple<Guid, MapObject>(id, serviceZone));

            Logger.SendMessage(1, ComponentName, String.Format("Трап выехал с площадки номер {0} в гараж.", serviceZone.Number));
                
            //возвращаем машину в гараж
            car.GoTo(serviceZone, Garage);

            Logger.SendMessage(1, ComponentName, String.Format("Трап вернулся с площадки номер {0} в гараж.", serviceZone.Number));
        }
    }
}