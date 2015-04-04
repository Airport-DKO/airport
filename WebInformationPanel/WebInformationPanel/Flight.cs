using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebInformationPanel
{
    public enum Cities
    {
        Tokyo,
        Paris,
        Rome,
        NewYork,
        Sydney,
        Brasilia,
        Antananarivo
    };

    public class Flight
    {
        public Guid number { get; set; }
        public Cities city { get; set; }
        public DateTime arrivalTime { get; set; }
        public DateTime takeoffTime { get; set; }

        public DateTime StartRegistrationTime { get; set; }
        public DateTime EndRegistrationTime { get; set; }

        public int EconomPassengersCount { get; set; }
        public int VipPassengersCount { get; set; } 
    }
}