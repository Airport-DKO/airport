using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using BaggageTractor.GmcVS;

namespace BaggageTractor
{
    /// <summary>
    /// Summary description for BaggageTractor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BaggageTractor : System.Web.Services.WebService
    {
        [WebMethod]
        public bool BaggageToAirport(MapObject place, int weightOfBaggage, int taskId)
        {
            var t = new Task(() => Worker.ToAirport(place, weightOfBaggage, taskId));
            t.Start();
            return true;
        }

        [WebMethod]
        public bool BaggageToPlain(MapObject place, int flightNumber, int taskId)
        {
            var t = new Task(() => Worker.ToPlain(place, flightNumber, taskId));
            t.Start();
            return true;
        }

        [WebMethod]
        public bool ToPlain(int flightNumber)
        {
            var count = Worker.GetWeightOfBaggage(flightNumber);
            return count > 0;
        }
    }
}
