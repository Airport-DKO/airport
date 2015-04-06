using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebPassengersGenerator.CheckInService;

namespace WebPassengersGenerator
{
    /// <summary>
    /// Summary description for WebServicePassengersGenerator
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePassengersGenerator : System.Web.Services.WebService
    {
        static PassengersGenerator passengersGenerator = new PassengersGenerator();

        [WebMethod]
        public void GenerateRandomPassengers(int count)
        {
            passengersGenerator.GenerateRandomPassengers(count);
        }

        [WebMethod]
        public void GeneratePassenger(Food food, int baggage)
        {
            passengersGenerator.GeneratePassenger(food, baggage);
        }

        [WebMethod]
        public void PassengerBehavior()
        {
            passengersGenerator.PassengerBehavior();
        }

        [WebMethod]
        public bool onPlane(Guid passengerId)
        {
            return passengersGenerator.onPlane(passengerId);
        }

        [WebMethod]
        public PassengersStatistic GetPassengersInfo()
        {
            return passengersGenerator.GetPassengersInfo();
        }
    }
}
