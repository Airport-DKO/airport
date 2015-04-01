using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FollowMe.GmcVS;

namespace FollowMe
{
    public static class Worker
    {
        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
        }

        public static void LeadPlane(MapObject from, MapObject to)
        {
            var car = new Car();
            car.GoTo(Garage,from); //подъезжаем к месту встречи самолета
            var planeId = WaitForPlane(); //ждем контакт с самолетом
            car.GoAndLeadTo(from, to, planeId); //едем и ведем самолет за собой
        }

        private static Guid WaitForPlane()
        {
            //TODO: запрашиваем у Генератора Самолета контакт FollowMe();
            return Guid.NewGuid();
        }
    }
}