using System;
using CateringTruck.AircraftGeneratorVS;
using CateringTruck.ChechinVS;
using CateringTruck.GscVS;
using MapObject = CateringTruck.GmcVS.MapObject;
using MapObjectType = CateringTruck.GmcVS.MapObjectType;

namespace CateringTruck
{
    public static class Worker
    {
        private static readonly MapObject Garage;
        private const string ComponentName = "CateringTruck";

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
            Logger.SendMessage(0, ComponentName,
                String.Format("Получено задание доставить питание на площадку {0} на рейс {1}", serviseZone.Number, flightNumber));
            
            var catering = new WebServiceCheckIn().GetCatering(flightNumber); //запрашиваем питание у Регистрации
            
            if (catering.Children + catering.Default + catering.Diabetic + catering.LowCalorie + catering.Vegetarian > 0) //проверить, что вернулся не пустой объект, т.е. что питание есть
            {
                Logger.SendMessage(0, ComponentName,
                    String.Format("Машина с питанием выехала для доставки его на площадку {0} на рейс {1}", serviseZone.Number, flightNumber));

                var car = new Car();
                car.GoTo(Garage, serviseZone); //подъезжаем к самолету

                new AircraftGenerator().LoadCatering(serviseZone, catering); //передаем питание Генератору Самолетов 
                SpecialThead.Sleep(50000);//изображаем деятельность

                Logger.SendMessage(1, ComponentName,
                    String.Format("Питание доставлено на борт {0}. Задание выполнено.", flightNumber));

                new GSC().Done(taskId); //сообщаем Управлению Наземным Обслуживанием, что задание выполнено

                Logger.SendMessage(0, ComponentName,
                    String.Format("Машина возвращается в гараж с площадки обслуживания {0}", serviseZone.Number));

                car.GoTo(serviseZone, Garage); //возвращаемся в гараж

                Logger.SendMessage(0, ComponentName,
                    String.Format("Машина вернулась в гараж с площадки обслуживания {0}", serviseZone.Number));
            }
            else
            {
                Logger.SendMessage(0, ComponentName,
                    String.Format("Питание на рейс {0} не получено. Задание считается выполненным.", flightNumber));
                new GSC().Done(taskId); //сообщаем Управлению Наземным Обслуживанием, что задание выполнено
            }
        }
    }
}