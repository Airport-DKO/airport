using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using ContainerLoader.GmcReference;

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

        [WebMethod]
        public bool ToServiceZone(MapObject place, int taskId)
        {
            var t = new Task(() => Worker.GoToServiceZone(place, taskId));
            t.Start();
            return true;
        }

        [WebMethod]
        public bool ToGarage(MapObject place)
        {
            var t = new Task(() => Worker.GoToGarage(place));
            t.Start();
            return true;
        }

        [WebMethod]
        public void Test()
        {
            int a = 5;
            // var her = new MapObject();
            // her.MapObjectType=MapObjectType.ServiceArea;
            // her.Number = 1;
            //// ToGarage(her);
        }
    }
}
