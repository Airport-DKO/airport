using System;
using System.Threading.Tasks;
using System.Web.Services;
using CateringTruck.GscVS;
using MapObject = CateringTruck.GmcVS.MapObject;

namespace CateringTruck
{
    /// <summary>
    /// Summary description for CateringTruck
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CateringTruck : System.Web.Services.WebService
    {
        /// <summary>
        /// Метод, который доставляет питание на борт
        /// </summary>
        /// <param name="serviseZone">площадка, на которой стоит самолет</param>
        /// <param name="flightNumber">номер рейса, багаж пассажиров которого следует погрузить</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        [WebMethod]
        public bool LoadFood(MapObject serviseZone, Guid flightNumber, ServiceTaskId taskId)
        {
            var t = new Task(() => Worker.CateringToPlain(serviseZone, flightNumber, taskId));
            t.Start(); //запускаем асинхронно

            return true;
        }
    }
}
