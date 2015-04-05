using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTicketSales
{
    public enum Class
    {
        Vip,
        Econom
    }
    public class Ticket
    {
        public Guid PassengerID { get; set; }
        public Guid FlightID { get; set; }
        public Class TicketClass { get; set; }
    }
}