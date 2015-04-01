using CateringTruck.GmcVS;

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
        public static void CateringToPlain(MapObject serviseZone, int flightNumber, int taskId)
        {
            //TODO: запрашиваем питание у Регистрации var catering = GetCatering(flightNumber);

            if (true) //TODO: проверить, что вернулся не пустой объект, т.е. что питание есть
            {
                var car = new Car();
                car.GoTo(Garage, serviseZone); //подъезжаем к самолету

                //TODO: передаем питание Генератору Самолетов LoadCatering(catering);

                //TODO: сообщаем Управлению Наземным Обслуживанием, что задание выполнено Done(taskId);

                car.GoTo(serviseZone, Garage); //возвращаемся в гараж
            }
        }
    }
}