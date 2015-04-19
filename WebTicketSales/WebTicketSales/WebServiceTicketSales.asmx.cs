using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebTicketSales
{
    /// <summary>
    /// Summary description for WebServiceTicketSales
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceTicketSales : System.Web.Services.WebService
    {
        private static TicketSales ticketseSales = new TicketSales();
        [WebMethod]
        public Ticket BuyTicket(Guid passengerId)
        {
            return ticketseSales.BuyTicket(passengerId);
        }

        [WebMethod]
        public bool ReturnTicket(Guid passengerId)
        {
            return ticketseSales.ReturnTicket(passengerId);
        }

        [WebMethod]
        public bool CheckTicket(Guid passengerid, Guid fligthid)
        {
            return ticketseSales.CheckTicket(passengerid, fligthid);
        }

        [WebMethod]
        public void Reset()
        {
            ticketseSales.Reset();
        }
    }
}
