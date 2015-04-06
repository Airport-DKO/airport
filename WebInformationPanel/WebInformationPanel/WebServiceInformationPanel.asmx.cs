using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebInformationPanel
{
    /// <summary>
    /// Summary description for WebServiceInformationPanel
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceInformationPanel : System.Web.Services.WebService
    {
        private static InformationPanel infpanel = new InformationPanel();
        
        [WebMethod]
        public List<Flight> GetFlightsForRegistration()
        {
            return infpanel.GetFlightsForRegistration();
        }

        [WebMethod]
        public List<Flight> GetFlightsForSales()
        {
            return infpanel.GetFlightsForSales();
        }
        [WebMethod]
        public bool IsFlightSoon(Guid flightNumber)
        {
            return infpanel.IsFlightSoon(flightNumber);
        }

        [WebMethod]
        public bool IsCheckInFinished(Guid flightNumber)
        {
            return infpanel.IsCheckInFinished(flightNumber);
        }

        [WebMethod]
        public void CreateFlight(DateTime takeoffTime, Cities city, int economPassengers, int vipPassengers)
        {
            infpanel.CreateFlight(takeoffTime, city, economPassengers, vipPassengers);
        }

        [WebMethod]
        public List<Flight> GetAvailableFlights()
        {
            return infpanel.GetAvailableFlights();
        }

        [WebMethod]
        public bool RegisterPlaneToFlight(Guid planeid, Guid FlightId)
        {
            return infpanel.RegisterPlaneToFlight(planeid, FlightId);
        }


        [WebMethod]
        public bool ReadyToTakeOff(Guid fligthID)
        {
            return infpanel.ReadyToTakeOff(fligthID);
        }

        [WebMethod]
        public void Reset()
        {
            infpanel.Reset();
        }
    }
}
