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
        private static List<Tuple<Guid, MapObject>> WhoWhere; //список, чтоб запоминать, где какой трап находится (используется для возврата в гараж)

        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
            WhoWhere = new List<Tuple<Guid, MapObject>>();
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
            var passangersCount =
                new WebServiceCheckIn().GetSimplePassengers(flightNumber).Length +
                new WebServiceCheckIn().GetVips(flightNumber).Length;

            if (passangersCount > 0) //если пассажиры есть - что-то делаем
            {
                var car = new Car();
                car.GoTo(Garage, serviceZone);
                WhoWhere.Add(new Tuple<Guid, MapObject>(car.Id, serviceZone)); //запоминаем, что на этой площадке находится погрузчик с некоторым идентификатором
            } //если пассажиров нет - считаем, что все сделано

            new GSC().Done(taskId); //сообщаем Управлению Наземным Обслуживанием, что задание выполнено
        }

        /// <summary>
        /// Метод, который отправляет погрузчик багажа в гараж, когда тот становится не нужен на площадке
        /// </summary>
        /// <param name="serviceZone">площадка, на которой находится обслуженный самолет и, соответственно, сам погрузчик багажа</param>
        /// <returns></returns>
        public static void GoToGarage(MapObject serviceZone)
        {
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
                return;

            //создаем машину со старым id
            Car car = new Car(id);

            //удаляем машину из списка 
            WhoWhere.Remove(new Tuple<Guid, MapObject>(id, serviceZone));

            //возвращаем машину в гараж
            car.GoTo(serviceZone, Garage);
        }
    }
}