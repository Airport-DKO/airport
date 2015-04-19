using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebTicketSales;

namespace WebCheckIn
{
    /// <summary>
    /// Summary description for WebServiceCheckIn
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceCheckIn : System.Web.Services.WebService
    {
        static CheckIn checkIn = new CheckIn();

        [WebMethod]
        public bool Registrate(Passenger passenger)
        {
            return checkIn.Registrate(passenger);
        }

        [WebMethod]
        public List<Guid> GetVips(Guid flightNumber)
        {
            return checkIn.GetVips(flightNumber);
        }

        [WebMethod]
        public List<Guid> GetSimplePassengers(Guid flightNumber)
        {
            return checkIn.GetSimplePassengers(flightNumber);
        }

        [WebMethod]
        public Catering GetCatering(Guid flightNumber)
        {
            return checkIn.GetCatering(flightNumber);
        }

        [WebMethod]
        public int GetBaggage(Guid flightNumber)
        {
            return checkIn.GetBaggage(flightNumber);
        }

        [WebMethod]
        public void Reset()
        {
            checkIn.Reset();
        }
    }
}
