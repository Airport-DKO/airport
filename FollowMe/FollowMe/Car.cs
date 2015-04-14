using System;
using System.Collections.Generic;
using System.Linq;
using FollowMe.AircraftGeneratorVS;
using FollowMe.GmcVS;
using CoordinateTuple = FollowMe.GmcVS.CoordinateTuple;
using MapObject = FollowMe.GmcVS.MapObject;

namespace FollowMe
{
    public class Car
    {
        private readonly Guid _id; //идентификатор машины, чтобы ее могли отличить среди других Управление Наземным Движением и Визуализатор
        private readonly MoveObjectType _type;
        private const int Speed = 3000;

        public Car()
        {
            _id = Guid.NewGuid();
            _type = MoveObjectType.FollowMeVan;
        }

        /// <summary>
        /// Метод, который заставляет машину ехать
        /// </summary>
        /// <param name="from">место отправления - должно совпадать с текущим местоположением машины</param>
        /// <param name="to">место назначения</param>
        public void GoTo(MapObject from, MapObject to)
        {
            var route = getRoute(from, to);
            go(route);
        }

        /// <summary>
        /// Метод, который запрашивает у Упревления Наземным Движением маршрут
        /// </summary>
        /// <param name="from">место отправления</param>
        /// <param name="to">место назначения</param>
        /// <returns></returns>
        private List<CoordinateTuple> getRoute(MapObject from, MapObject to)
        {
            var gmc = new GMC(); //объект для связи с Управлением Наземным Движением (чтобы вызвать веб-сервис этой компоненты)

            List<CoordinateTuple> route;
            while (true)
            {
                route = gmc.GetRoute(from, to).ToList(); //УНД возвращает список координат, по которым надо проехать
                if (route.Count == 0) //если маршрут вернулся пустым - ехать пока что нельзя (уборка снега) - через некоторое время повторяем запрос
                {
                    SpecialThead.Sleep(100000);
                }
                else
                {
                    break; //когда получили маршрут - выходим из цикла
                }
            }

            return route;
        }

        /// <summary>
        /// Метод, который осуществляет передвижение машины, согласуя действия с Управлением Наземным Движением
        /// </summary>
        /// <param name="route">маршрут, предварительно запрошенный у Управленя Наземным Движением</param>
        private void go(List<CoordinateTuple> route)
        {
            var gmc = new GMC(); //объект для связи с Управлением Наземным Движением (чтобы вызвать веб-сервис этой компоненты)

            int stepNumber = 0;
            while (stepNumber < route.Count) //пока не дойдем до конца массива, содержащего маршрут
            {
                if (gmc.Step(route[stepNumber], _type, _id)) //УНД возвращает разрешение на движение на переданную координату или запрет 
                {
                    //если шаг сделать удалось - передвигаемся на следующий индекс массива, содержащего маршрут
                    stepNumber++;}
                SpecialThead.Sleep(Speed);
            }
        }

        /// <summary>
        /// Метод, который осуществляет передвижение машины и согласование шагов с Генератором Самолетов
        /// </summary>
        /// <param name="from">место отправления</param>
        /// <param name="to">место назначения</param>
        /// <param name="who">идентификатор самолета, который следует скоординировать</param>
        public void GoAndLeadTo(MapObject from, MapObject to, Guid who)
        {
            var route = getRoute(from, to);
            goAndLead(route, who);
        }

        /// <summary>
        /// Метод, который осуществляет передвижение машины по маршруту и координацию движения самолета(в Генераторе Самолета)
        /// </summary>
        /// <param name="route"></param>
        private void goAndLead(List<CoordinateTuple> route, Guid who)
        {
            var gmc = new GMC(); //объект для связи с Управлением Наземным Движением (чтобы вызвать веб-сервис этой компоненты)
            var airplane = new AircraftGenerator();

            int stepNumber = 0;
            while (stepNumber < route.Count) //пока не дойдем до конца массива, содержащего маршрут
            {
                if (gmc.Step(route[stepNumber], _type, _id)) //УНД возвращает разрешение на движение на переданную координату или запрет 
                {
                    if (stepNumber > 0)
                    {
                        airplane.DoStep(who, route[stepNumber - 1]);//передаем Генератору Самолетов координаты(для машины - предыдушего места положения, для самолета - следующего места)
                    }
                    //если шаг сделать удалось - передвигаемся на следующий индекс массива, содержащего маршрут
                    stepNumber++;
                    //TODO: между интервалами посылки таких запросов необходимо делать Sleep(N/Speed), где N-число, полученное от Метрологической службы(Время)
                }
            }

            //чтобы самолет оказался ровно на площадке обслуживания передаем Генератору Самолетов последние две координаты 
            airplane.DoStep(who, route[route.Count - 2]);
            airplane.DoStep(who, route[route.Count - 1]); 
        }
    }
}
