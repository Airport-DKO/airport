using System;
using CateringTruck.AircraftGeneratorVS;
using CateringTruck.GscVS;
using MapObject = CateringTruck.GmcVS.MapObject;
using MapObjectType = CateringTruck.GmcVS.MapObjectType;

namespace CateringTruck
{
    public static class Worker
    {
        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
        }

        /// <summary>
        /// Метод, который доставляет питание на борт
        /// </summary>
        /// <param name="serviseZone">площадка, на которой стоит самолет</param>
        /// <param name="flightNumber">номер рейса, багаж пассажиров которого следует погрузить</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        public static void CateringToPlain(MapObject serviseZone, Guid flightNumber, ServiceTaskId taskId)
        {
            //TODO: запрашиваем питание у Регистрации var catering = GetCatering(flightNumber);

            if (true) //TODO: проверить, что вернулся не пустой объект, т.е. что питание есть
            {
                var car = new Car();
                car.GoTo(Garage, serviseZone); //подъезжаем к самолету

                // new AircraftGenerator().LoadCatering(serviseZone, catering); //TODO: передаем питание Генератору Самолетов 

                new GSC().Done(taskId);//сообщаем Управлению Наземным Обслуживанием, что задание выполнено

                car.GoTo(serviseZone, Garage); //возвращаемся в гараж
            }
        }
    }
}