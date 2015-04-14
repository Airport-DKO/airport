using System;
using Deicer.AircraftGeneratorVS;
using MapObject = Deicer.GmcVS.MapObject;
using MapObjectType = Deicer.GmcVS.MapObjectType;

namespace Deicer
{
    public class Worker
    {
        private static readonly MapObject Garage;
        private const string ComponentName = "Deicer";

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
            
            Logger.SendMessage(0, ComponentName, 
                String.Format("Машина с антиобледенителем вызвана на площадку номер {0}", serviсeZone.Number));

            car.GoTo(Garage, serviсeZone); //подъезжаем к самолету

            Logger.SendMessage(0, ComponentName,
                String.Format("Машина с антиобледенителем прибыла на площадку номер {0}.", serviсeZone.Number));

            SpecialThead.Sleep(50000);//будем считать, что, подъехав к самолету, мы окропили его специальной жидкостью

            Logger.SendMessage(1, ComponentName,
                String.Format("Борт на площадке {0} обработан антиобледенителем", serviсeZone.Number));

            new AircraftGenerator().Douched(serviсeZone);

            Logger.SendMessage(0, ComponentName,
                String.Format("Машина возвращается в гараж с площадки номер {0}.", serviсeZone.Number));

            car.GoTo(serviсeZone, Garage); //возвращаемся в гараж

            Logger.SendMessage(0, ComponentName,
                String.Format("Машина вернулась в гараж с площадки номер {0}.", serviсeZone.Number));
        }
    }
}