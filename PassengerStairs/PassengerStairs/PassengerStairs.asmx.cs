using System.Threading.Tasks;
using System.Web.Services;
using PassengerStairs.GscVS;
using MapObject = PassengerStairs.GmcVS.MapObject;

namespace PassengerStairs
{
    /// <summary>
    /// Summary description for PassengerStairs
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PassengerStairs : System.Web.Services.WebService
    {
        /// <summary>
        /// Метод, который вызывает трап на площадку обслуживания самолета
        /// </summary>
        /// <param name="serviceZone">площадка, на которой находится обслуживаемый самолет</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        [WebMethod]
        public bool ToServiceZone(MapObject serviceZone, ServiceTaskId taskId)
        {
            var t = new Task(() => Worker.GoToServiceZone(serviceZone, taskId));
            t.Start(); //запускаем асинхронно

            return true;
        }

        /// <summary>
        /// Метод, который отправляет трап в гараж, когда тот становится не нужен на площадке
        /// </summary>
        /// <param name="serviceZone">площадка, на которой находится обслуженный самолет и, соответственно, сам погрузчик багажа</param>
        /// <returns></returns>
        [WebMethod]
        public bool ToGarage(MapObject serviceZone)
        {
            var t = new Task(() => Worker.GoToGarage(serviceZone));
            t.Start(); //запускаем асинхронно

            return true;
        }

    }
}
