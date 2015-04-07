using System.Threading.Tasks;
using System.Web.Services;
using Refueler.GscVS;
using MapObject = Refueler.GmcVS.MapObject;

namespace Refueler
{
    /// <summary>
    /// Summary description for Refueler
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Refueler : System.Web.Services.WebService
    {
        /// <summary>
        /// Метод, который вызывает топливозаправщик и заправляет самолет
        /// </summary>
        /// <param name="serviceZone">площадка, на которой находится обслуживаемый самолет</param>
        /// <param name="litersOfFuel">количество требуемого топлива в литрах</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        [WebMethod]
        public bool Fill(MapObject serviceZone, int litersOfFuel, ServiceTaskId taskId)
        {
            var t = new Task(() => Worker.FillPlane(serviceZone, litersOfFuel, taskId));
            t.Start();
            return true;
        }
    }
}
