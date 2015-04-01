using Deicer.GmcVS;

namespace Deicer
{
    public class Worker
    {
        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
        }

        /// <summary>
        /// Метод, который отправляет машину с душем из антиобледенительной жидкости
        /// </summary>
        /// <param name="serviсeZone">площадка, на которой находится обслуживаемый самолет</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        public static void DouchePlane(MapObject serviсeZone, int taskId)
        {
            var car = new Car();

            car.GoTo(Garage, serviсeZone); //подъезжаем к самолету

            //будем считать, что, подъехав к самолету, мы окропили его специальной жидкостью

            //TODO: сообщаем Управлению Наземным Обслуживанием, что задание выполнено Done(taskId);

            car.GoTo(serviсeZone, Garage); //возвращаемся в гараж
        }
    }
}