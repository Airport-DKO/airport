using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PassengerStairs.GmcVS;

namespace PassengerStairs
{
    public class Car
    {
        private readonly Guid _id;

        public Guid id { get { return id; } }
        public Car()
        {
            _id = Guid.NewGuid();
        }

        public Car(Guid id)
        {
            _id = id;
        }

        public void GoTo(MapObject from, MapObject to)
        {
            var route = getRoute(from, to); //запрашиваем маршрут
            go(route); //едем
        }

        private List<CoordinateTuple> getRoute(MapObject from, MapObject to)
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

        private void go(List<CoordinateTuple> route)
        {
            var gmc = new GMC();

            //едем
            int stepNumber = 0;
            while (stepNumber < route.Count)
            {
                if (gmc.Step(route[stepNumber], MoveObjectType.PassengerStairs, _id)) //УНД принимает пару чисел-координат,возвращает разрешение на движение на переданную координату или запрет 
                {
                    stepNumber++;
                    //TODO: между интервалами посылки таких запросов необходимо делать Sleep(N/Speed), где N-число, полученное от Метрологической службы(Время)
                }
            }
        }
    }
}