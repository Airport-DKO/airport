using System;
using InformationPanelGUI.InformationPanelWs;

namespace InformationPanelGUI
{
    public class FlightGuiClass 
    {
        public FlightGuiClass(DateTime arriavalTime, DateTime departureTime, DateTime startRegistration, DateTime endRegistration, Cities city, int passengersStandart, int passengersVip, string status)
        {
            ArriavalTime = arriavalTime;
            DepartureTime = departureTime;
            StartRegistration = startRegistration;
            EndRegistration = endRegistration;
            City = city;
            PassengersStandart = passengersStandart;
            PassengersVip = passengersVip;
            Status = status;

        }

        public FlightGuiClass()
        {
        }
        public String FlightNumber { get; set; }

        public DateTime ArriavalTime { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime StartRegistration { get; set; }

        public DateTime EndRegistration { get; set; }

        public Cities City { get; set; }

        public Int32 PassengersStandart { get; set; }

        public Int32 PassengersVip { get; set; }

        public String Status { get; set; }
    }
}