using System;
using System.Collections.Generic;
using System.Linq;
using CateringTruck.GmcVS;

namespace CateringTruck
{
    public class Car
    {
        private readonly Guid _id; //идентификатор машины, чтобы ее могли отличить среди других Управление Наземным Движением и Визуализатор
        private readonly MoveObjectType _type;
        private const int Speed = 10000;

        public Car()
        {
            _id = Guid.NewGuid();
            _type = MoveObjectType.CateringTruck;
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
                    stepNumber++;
                }
                SpecialThead.Sleep(Speed);//делаем задержку, специально написанный метод Sleep внутри себя учитывает коэффициент метрологической службы
            }
        }
    }
}