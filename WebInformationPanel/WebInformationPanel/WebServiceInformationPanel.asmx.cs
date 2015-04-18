﻿using System;
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
        public void CreateFlight(DateTime arrivalTime, DateTime takeoffTime, Cities city, int economPassengers, int vipPassengers)
        {
            infpanel.CreateFlight(arrivalTime, takeoffTime, city, economPassengers, vipPassengers);
        }

        [WebMethod]
        public List<Flight> GetAvailableFlights()
        {
            return infpanel.GetAvailableFlights();
        }

        [WebMethod]
        public Flight RegisterPlaneToFlight(Guid planeid, Guid FlightId)
        {
            return infpanel.RegisterPlaneToFlight(planeid, FlightId);
        }

        [WebMethod]
        public bool IsFlightRightNow(Guid flightNumber)
        {
            return infpanel.IsFlightRightNow(flightNumber);
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

        [WebMethod]
        public List<Flight> GetFlightsList()
        {
            return infpanel.GetFlightsList();
        }

        [WebMethod]
        public string GetStatus(Guid flightNumber)
        {
            return infpanel.GetStatus(flightNumber);
        }

        [WebMethod]
        public bool CanReturnTicket(Guid flightNumber)
        {
            return infpanel.CanReturnTicket(flightNumber);
        }
    }
}
