using System.Threading.Tasks;
using System.Web.Services;
using Deicer.GmcVS;

namespace Deicer
{
    /// <summary>
    /// Summary description for Deicer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Deicer : System.Web.Services.WebService
    {
        /// <summary>
        /// Метод, который вызывает машину с душем из антиобледенительной жидкости
        /// </summary>
        /// <param name="serviceZone">площадка, на которой находится обслуживаемый самолет</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        [WebMethod]
        bool DouchePlane(MapObject serviceZone, int taskId)
        {
            var t = new Task(() => Worker.DouchePlane(serviceZone, taskId));
            t.Start(); //вызываем асинхронно

            return true;
        }
    }
}
