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
        /// <returns></returns>
        [WebMethod]
        public bool DouchePlane(MapObject serviceZone)
        {
            var t = new Task(() => Worker.DouchePlane(serviceZone));
            t.Start(); //вызываем асинхронно

            return true;
        }
    }
}
