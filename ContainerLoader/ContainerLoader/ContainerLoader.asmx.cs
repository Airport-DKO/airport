using System.Threading.Tasks;
using System.Web.Services;
using ContainerLoader.GscVS;
using MapObject = ContainerLoader.GmcVS.MapObject;

namespace ContainerLoader
{
    /// <summary>
    /// Summary description for ContainerLoader
    /// </summary>
    [WebService(Namespace = "Airport-DKO-Container-Loader")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ContainerLoader : System.Web.Services.WebService
    {
        /// <summary>
        /// Метод, который вызывает погрузчик багажа на площадку обслуживания самолета
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
        /// Метод, который отправляет погрузчик багажа в гараж, когда тот становится не нужен на площадке
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
