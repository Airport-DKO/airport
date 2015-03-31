using System;
using System.Collections.Generic;
using PassengerStairs.GmcVS;

namespace PassengerStairs
{
    public static class Worker
    {
        private static List<Tuple<Guid, MapObject>> WhoWhere;
 
        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject();
            Garage.MapObjectType = MapObjectType.Garage;

            WhoWhere = new List<Tuple<Guid, MapObject>>();
        }

        public static void GoToServiceZone(MapObject place, int taskId)
        {
            var car = new Car();
            car.GoTo(Garage, place);

            WhoWhere.Add(new Tuple<Guid, MapObject>(car.id, place));

            //TODO: РАССКОММЕНТИТЬ, КОГДА УНО БУДЕТ ГОТОВ
            //Done(taskId); //возвращаем УНО сообщение о выполненном задании
        }

        public static void GoToGarage(MapObject place)
        {
            //пытаемся найти машинку на стоянке в списке и достать ее id
            Guid id = Guid.Empty;
            foreach (var tuple in WhoWhere)
            {
                if (tuple.Item2 == place)
                {
                    id = tuple.Item1;
                    break;
                }
            }

            //создаем машинку либо со старым id, либо с новым
            Car car = (id == Guid.Empty ? new Car() : new Car(id));

            car.GoTo(place, Garage);
        }
    }
}