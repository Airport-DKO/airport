using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using Aircraft_Generator.Commons;
using Aircraft_Generator.GmcVs;

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
        public bool CreateNewPlane(string name, PlaneType type, int fuelNeed, int currentStandartPassengers,
            int currentVipPassengers, int currentBaggage, bool hasArrivalPassengers)
        {
            return Core.Instance.CreateNewPlane(name, type, fuelNeed, currentStandartPassengers, currentVipPassengers,
                true, currentBaggage);
        }

        [WebMethod]
        public List<Plane> GetAllPlanes()
        {
            return Core.Instance.Planes;
        }

        [WebMethod]
        public void BindPlaneToFlight(Guid planeId, Guid flightId)
        {
            Core.Instance.BindPlaneToFlight(planeId, flightId);
        }

        [WebMethod]
        public bool UnloadBaggage(MapObject serviseZone, int weightOfBaggage)
        {
            return Core.Instance.UnloadBaggage(serviseZone, weightOfBaggage);
        }

        [WebMethod]
        public bool LoadBaggage(MapObject serviseZone, int weightOfBaggage)
        {
            return Core.Instance.LoadBaggage(serviseZone, weightOfBaggage);
        }

        [WebMethod]
        public bool LoadPassengers(MapObject serviseZone, List<Guid> passengers)
        {
            return Core.Instance.LoadPassangers(serviseZone, passengers);
        }

        [WebMethod]
        public bool UnloadPassengers(MapObject serviseZone, int countOfPassengers)
        {
            return Core.Instance.UnloadPassangers(serviseZone, countOfPassengers);
        }

        [WebMethod]
        public bool LoadCatering(MapObject serviseZone, Catering catering)
        {
            //TODO
            return false;
        }

        [WebMethod]
        public bool FollowMe(Guid planeId)
        {
            return Core.Instance.FollowMe(planeId);
        }

        [WebMethod]
        public bool DoStep(Guid planeId, CoordinateTuple step)
        {
            return Core.Instance.DoStep(planeId, step);
        }

        [WebMethod]
        public bool FollowMeComplete(Guid planeId)
        {
            return Core.Instance.FollowMeComplete(planeId);
        }
    }
}