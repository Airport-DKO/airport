using System.Threading.Tasks;
using System.Web.Services;
using ContainerLoader.GmcVS;

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

    }
}
