using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public static void DouchePlane(MapObject place, int taskId)
        {
            var car = new Car();
            car.GoTo(Garage, place);

            //TODO: РАССКОМЕНТИТЬ, КОГДА БУДЕТ УНО
            //Done(taskId);

            car.GoTo(place, Garage);
        }
    }
}