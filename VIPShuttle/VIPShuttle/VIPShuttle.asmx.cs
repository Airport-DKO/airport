using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using VIPShuttle.GmcVS;

namespace VIPShuttle
{
    /// <summary>
    /// Summary description for VIPShuttle
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VIPShuttle : System.Web.Services.WebService
    {

        [WebMethod]
        public bool PassengersToAirport(MapObject place, int countOfPassengers, int taskId)
        {
            var t = new Task(() => Worker.ToAirport(place, countOfPassengers, taskId));
            t.Start();
            return true;
        }

        [WebMethod]
        public bool PassengersToPlain(MapObject place, int flightNumber, int taskId)
        {
            var t = new Task(() => Worker.ToPlain(place, flightNumber, taskId));
            t.Start();
            return true;
        }

        [WebMethod]
        public bool ToPlain(int flightNumber)
        {
            var count = Worker.GetPassengersCount(flightNumber);
            return count>0;
        }

    }
}
