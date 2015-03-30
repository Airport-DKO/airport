using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using ContainerLoader.GmcReference;

namespace ContainerLoader
{
    public static class Worker
    {
        private static readonly MapObject Garage;

        static Worker()
        {
            Garage = new MapObject();
            Garage.MapObjectType = MapObjectType.Garage;
        }

        public static void GoToServiceZone(MapObject place, int taskId)
        {
            var route = getRoute(Garage, place); //запрашиваем маршрут
            go(route); //едем
            //Done(taskId); //возвращаем УНО сообщение о выполненном задании
        }

        public static void GoToGarage(MapObject place)
        {
            var route = getRoute(place, Garage); //запрашиваем маршрут
            go(route); //едем
        }


        private static List<CoordinateTuple> getRoute(MapObject from, MapObject to)
        {
            var route = new List<CoordinateTuple>();
            var gmc = new GMC();

            while (true)
            {
                route = gmc.GetRoute(from, to).ToList(); //УНД принимает объект, к которому планирует направиться машинка, возвращает список координат, по которым надо проехать
                if (route.Count == 0)
                {
                    Thread.Sleep(100000);
                }
                else
                {
                    break;
                }
            }

            return route;
        }

        private static void go(List<CoordinateTuple> route)
        {
            var myId = Guid.NewGuid();
            var gmc = new GMC();

            //едем
            int stepNumber = 0;
            while (stepNumber < route.Count)
            {
                if (gmc.Step(route[stepNumber], MoveObjectType.ContainerLoader, myId)) //УНД принимает пару чисел-координат,возвращает разрешение на движение на переданную координату или запрет 
                {
                    stepNumber++;
                    //TODO
                    //между интервалами посылки таких запросов необходимо делать Sleep(N/Speed), где N-число, полученное от Метрологической службы(Время)
                }
            }
        }
    }
}