using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        [WebMethod]
        bool DoWork(MapObject place, int taskId)
        {
            var t = new Task(() => Worker.DouchePlane(place, taskId));
            t.Start();
            return true;
        }
    }
}
