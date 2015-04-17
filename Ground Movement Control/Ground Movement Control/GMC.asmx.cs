using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using Ground_Movement_Control.Commons;

namespace Ground_Movement_Control
{
    /// <summary>
    ///     Summary description for GMC
    /// </summary>
    [WebService(Namespace = "Airport")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GMC : WebService
    {
        /// <summary>
        ///     Возвращает маршрут для следования из точки from в точку to
        /// </summary>
        /// <param name="from">Текущее расположение объекта</param>
        /// <param name="to">Куда нужно приехать</param>
        /// <returns>Список координат</returns>
        [WebMethod]
        public List<CoordinateTuple> GetRoute(MapObject from, MapObject to)
        {
            return Core.Instance.GetRoute(from, to);
        }

        /// <summary>
        ///     Запрос у УНД разрешение на передвижение в определенную точку
        /// </summary>
        /// <param name="coordinate">Координаты точки, куда нужно переместиться</param>
        /// <param name="type">Тип объекта (самолет, автобус, трап и т.п.)</param>
        /// <param name="id">GUID объекта</param>
        /// <returns>true - если УВД разрешает, false - если нет</returns>
        [WebMethod]
        public bool Step(CoordinateTuple coordinate, MoveObjectType type, Guid id)
        {
            return Core.Instance.Step(coordinate.X, coordinate.Y, type, id);
        }

        /// <summary>
        ///     Запрос на взлетно-посадочную полосу
        /// </summary>
        /// <param name="planeGuid">Guid самолета, который хочет сесть</param>
        /// <returns>null - если запрет, MapObject полосы в положительном случае</returns>
        [WebMethod]
        public bool CheckRunwayAwailability(Guid planeGuid)
        {
            return Core.Instance.CheckRunwayAwailability(planeGuid);
        }

        /// <summary>
        ///     Информирует самолет о зоне обслуживания, которая забронирована для него
        /// </summary>
        /// <param name="planeGuid">Guid самолета</param>
        /// <returns>Map Object зоны обслуживания</returns>
        [WebMethod]
        public MapObject GetPlaneServiceZone(Guid planeGuid)
        {
            return Core.Instance.GetPlaneServiceZone(planeGuid);
        }

        /// <summary>
        ///     Освобождаем впп
        /// </summary>
        [WebMethod]
        public void RunwayRelease()
        {
            Core.Instance.RunwayRelease();
        }

       /// <summary>
       ///      Метод возвращает рабочую впп
       /// </summary>
       /// <returns>Впп</returns>
        [WebMethod]
        public MapObject GetRunway()
        {
            return Core.Instance.GetRunway();
        }


        /// <summary>
        ///     Возвращает список всех зон обслуживания
        /// </summary>
        /// <returns>Список MapObject ServiceZone</returns>
        [WebMethod]
        public List<MapObject> GetServiceZones()
        {
            return Core.Instance.GetServiceZones();
        }

        [WebMethod]
        public void SnowCleanFinished()
        {
            Core.Instance.SnowCleanFinished();
        }

        [WebMethod]
        public void Reset()
        {
            Core.Instance.Reset();
        }
    }
}