using System;
using System.Threading.Tasks;
using System.Web.Services;
using VIPShuttle.GscVS;
using MapObject = VIPShuttle.GmcVS.MapObject;

namespace VIPShuttle
{
    /// <summary>
    /// Summary description for VIPShuttle
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class VIPShuttle : System.Web.Services.WebService
    {
        /// <summary>
        /// Метод, который служит для перемещения пассажиров с самолета в аэропорт
        /// </summary>
        /// <param name="serviseZone">площадка, на которой стоит самолет</param>
        /// <param name="countOfPassengers">количество пассажиров для выгрузки</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        [WebMethod]
        public bool UnloadPassengers(MapObject serviseZone, int countOfPassengers, ServiceTaskId taskId)
        {
            var t = new Task(() => Worker.ToAirport(serviseZone, countOfPassengers, taskId));
            t.Start();//запускаем выполнение асинхронно

            return true;
        }

        /// <summary>
        /// Метод, который служит для перемещения пассажиров из аэропорта на самолет, изменяет свойства пассажиров
        /// </summary>
        /// <param name="place">площадка, на которой стоит самолет</param>
        /// <param name="flightNumber">номер рейса</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        [WebMethod]
        public bool LoadPassengers(MapObject place, Guid flightNumber, ServiceTaskId taskId)
        {
            var t = new Task(() => Worker.ToPlain(place, flightNumber, taskId));
            t.Start();//запускаем выполнение асинхронно

            return true;
        }

        /// <summary>
        /// Метод, который позволяет определить, есть ли пассажиры на данный рейс
        /// </summary>
        /// <param name="flightNumber">номер рейса</param>
        /// <returns></returns>
        [WebMethod]
        public bool ToPlain(Guid flightNumber)
        {
            var count = Worker.GetPassengers(flightNumber).Count; //запрашиваем количество пассажиров
            return count > 0; //возвращаем true, если пассажиры есть
        }
    }
}
