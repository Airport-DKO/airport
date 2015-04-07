using System;
using FollowMe.AircraftGeneratorVS;
using MapObject = FollowMe.GmcVS.MapObject;
using MapObjectType = FollowMe.GmcVS.MapObjectType;

namespace FollowMe
{
    public static class Worker
    {
        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
        }

        public static void LeadPlane(MapObject from, MapObject to, Guid planeId)
        {
            var car = new Car();
            car.GoTo(Garage,from); //подъезжаем к месту встречи самолета
            new AircraftGenerator().FollowMe(planeId); //ожидаем самолет
            car.GoAndLeadTo(from, to, planeId); //едем и ведем самолет за собой
            new AircraftGenerator().FollowMeComplete(planeId); //оповещаем УНД, что сопровождение окончено
        }
    }
}