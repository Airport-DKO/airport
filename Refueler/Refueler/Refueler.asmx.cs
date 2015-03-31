using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using Refueler.GmcVS;

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

        [WebMethod]
        public bool Fill(MapObject place, int litersOfFuel, int taskId)
        {
            var t = new Task(() => Worker.FillPlane(place, litersOfFuel, taskId));
            t.Start();
            return true;
        }
    }
}
