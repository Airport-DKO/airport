using System;
using FollowMe.AircraftGeneratorVS;
using MapObject = FollowMe.GmcVS.MapObject;
using MapObjectType = FollowMe.GmcVS.MapObjectType;

namespace FollowMe
{
    public static class Worker
    {
        private static readonly MapObject Garage;
        public const string ComponentName = "FollowMe";

        static Worker()
        {
            Garage = new MapObject { MapObjectType = MapObjectType.Garage };
        }

        public static void LeadPlane(MapObject from, MapObject to, Guid planeId)
        {
            var car = new Car();

            Logger.SendMessage(0, ComponentName, String.Format("FollowMe выехала на встречу самолету {0}", planeId));

            car.GoTo(Garage,from); //подъезжаем к месту встречи самолета

            Logger.SendMessage(0, ComponentName, String.Format("FollowMe ожидает самолет {0}", planeId));

            new AircraftGenerator().FollowMe(planeId); //ожидаем самолет

            Logger.SendMessage(0, ComponentName, String.Format("FollowMe сопровождает самолет {0}", planeId));

            car.GoAndLeadTo(from, to, planeId); //едем и ведем самолет за собой

            Logger.SendMessage(1, ComponentName, String.Format("FollowMe доставила самолет {0} на площадку {1}", planeId, to.Number));

            new AircraftGenerator().FollowMeComplete(planeId); //оповещаем УНД, что сопровождение окончено

            Logger.SendMessage(0, ComponentName, "FollowMe возвращается в гараж");

            car.GoTo(to, Garage); //вернули followme в гараж

            Logger.SendMessage(0, ComponentName, "FollowMe вернулась в гараж");
        }
    }
}