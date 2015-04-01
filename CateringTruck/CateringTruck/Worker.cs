using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CateringTruck.GmcVS;

namespace CateringTruck
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

        public static void CateringToPlain(MapObject place, int flightNumber, int taskId)
        {
            //TODO: ВЗЯТЬ ЕДУ У РЕГИСТРАЦИИ
            var car = new Car();
            car.GoTo(Garage,place);

            //TODO: ПЕРЕДАТЬ ЕДУ ГС
            //TODO: РАССКОМЕНТИТЬ, КОГДА БУДЕТ УНО
            //Done(taskId);

            car.GoTo(place, Garage);
        }
    }
}