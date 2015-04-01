using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using CateringTruck.GmcVS;

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

        [WebMethod]
        public bool LoadFood(MapObject place, int flightNumber, int taskId)
        {
            var t = new Task(() => Worker.CateringToPlain(place, flightNumber, taskId));
            t.Start();
            return true;
        }
    }
}
