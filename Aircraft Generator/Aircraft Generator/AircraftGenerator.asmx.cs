using System.ComponentModel;
using System.Web.Services;
using Aircraft_Generator.Commons;

namespace Aircraft_Generator
{
    /// <summary>
    ///     Summary description for AircraftGenerator
    /// </summary>
    [WebService(Namespace = "DKO-Ariport-Aircraft-Generator")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AircraftGenerator : WebService
    {
        [WebMethod]
        public bool CreateNewPlane(string name, PlaneType type, int fuelNeed, int maxStandartPassengers,
            int maxVipPassengers, bool hasArrivalPassengers)
        {
            return Core.Instance.CreateNewPlane(name, type, fuelNeed, maxStandartPassengers, maxVipPassengers,
                hasArrivalPassengers);
        }
    }
}