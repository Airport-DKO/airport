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
        /// <returns></returns>
        public static void DouchePlane(MapObject serviсeZone)
        {
            var car = new Car();

            car.GoTo(Garage, serviсeZone); //подъезжаем к самолету

            //будем считать, что, подъехав к самолету, мы окропили его специальной жидкостью

            //TODO: сообщаем ГС, что задание выполнено Douched(serviсeZone);

            car.GoTo(serviсeZone, Garage); //возвращаемся в гараж
        }
    }
}