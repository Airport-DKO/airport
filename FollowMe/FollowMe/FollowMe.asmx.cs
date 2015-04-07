using System;
using System.Threading.Tasks;
using System.Web.Services;
using FollowMe.GmcVS;

namespace FollowMe
{
    /// <summary>
    /// Summary description for FollowMe
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FollowMe : System.Web.Services.WebService
    {
        /// <summary>
        /// Метод, который вызывает машину Follow Me
        /// </summary>
        /// <param name="from">место, где необходимо встретить самолет</param>
        /// <param name="to">место, куда необходимо привести самолет</param>
        /// <param name="planeId">идентификатор самолета</param>
        /// <returns></returns>
        [WebMethod]
        public bool LeadPlane(MapObject from, MapObject to, Guid planeId)
        {
            Task t = new Task(() => Worker.LeadPlane(from, to, planeId));
            t.Start();

            return true;
        }
    }
}
