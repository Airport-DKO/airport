using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aircraft_Generator.Commons;
using Aircraft_Generator.GmcVs;
using Aircraft_Generator.GscWs2;
using Aircraft_Generator.InformationPanelWS;
using Aircraft_Generator.TowerService;
using MapObject = Aircraft_Generator.GmcVs.MapObject;

namespace Aircraft_Generator
{
    public class Core
    {
        #region Singleton_realization

        private static readonly Lazy<Core> _instance =
            new Lazy<Core>(() => new Core());

        public static Core Instance
        {
            get { return _instance.Value; }
        }

        #endregion

        private readonly List<Plane> _createdPlanes;
        private readonly GMC _gmc;
        private readonly GSC _gsc;
        private readonly Tower _tower;
        private readonly WebServiceInformationPanel _panel;

        private Core()
        {
            _createdPlanes = new List<Plane>();
            _tower = new Tower();
            _gmc = new GMC();
            _gsc = new GSC();
            _panel=new WebServiceInformationPanel();
        }

        public List<Plane> Planes
        {
            get { return _createdPlanes; }
        }

        public bool CreateNewPlane(String name, PlaneType type, int fuelNeed,
            int maxStandartPassengers, int maxVipPassengers, bool hasArrivalPassengers)
        {
            var plane = new Plane(name, PlaneState.Arrival, type, fuelNeed, maxStandartPassengers, maxVipPassengers,
                hasArrivalPassengers);
            _createdPlanes.Add(plane);
            var task = new Task(() => PlaneLanding(plane));
            task.Start();
            return true;
        }

        public InformationPanelWS.Flight[] GetActualFlights()
        {
            _panel.CreateFlight(DateTime.Now,Cities.Brasilia, 545,40);
            var test = _panel.GetAvailableFlights();
            return test;
        }

        public bool LoadPassangers(MapObject serviceZone, List<Guid> passengersGuids)
        {
            var plane = Planes.First(p => p.ServiceZone.Number == serviceZone.Number);
            plane.CurrentStandartPassengers += passengersGuids.Count;
            return true;
        }

        public bool UnloadPassangers(MapObject serviceZone, int countOfPassengers)
        {
            //TODO Needed realization
            return true;
        }

        public bool LoadBaggage(MapObject serviseZone, int weightOfBaggage)
        {
            // TODO: Needed realization
            return true;
        }

        public bool UnloadBaggage(MapObject serviseZone, int weightOfBaggage)
        {
            // TODO: Needed realization
            return true;
        }

        public bool FollowMe(Guid planeId)
        {
            PlaneTaxingToServiceZone(planeId);
            return true;
        }

        public bool DoStep(Guid planeId, CoordinateTuple step)
        {
            while (true)
            {
                bool result = _gmc.Step(step, MoveObjectType.Plane, planeId);
                if (result)
                {
                    break;
                }
                Sleep(1000);
            }
            return true;
        }

        public bool FollowMeComplete(Guid planeId)
        {
            PlaneIsReadyToService(planeId);
            return true;
        }


        private double GetTimeCoef()
        {
            // TODO: коэффициент от метрологической службы
            return 1;
        }

        private void Sleep(int time)
        {
            int sleepTime = Convert.ToInt32(time*GetTimeCoef());
            Thread.Sleep(sleepTime);
        }

        private void PlaneLanding(Plane plane)
        {
            while (!CheckTime(plane.Flight.arrivalTime))
            {
                Sleep(5000);
            }

            MapObject runway;
            while (true)
            {
                runway = _tower.LandingRequest(plane.Id);
                if (runway == null)
                {
                    Sleep(10000);
                }
                else
                {
                    break;
                }
            }

            plane.State = PlaneState.Landing;
        }

        private void PlaneTaxingToServiceZone(Guid planeGuid)
        {
            Plane plane = _createdPlanes.First(p => p.Id == planeGuid);
            plane.State = PlaneState.TaxingToRunway;
            // TODO: Сообщить GMC о том, что полоса освободилась
        }

        private void PlaneIsReadyToService(Guid planeGuid)
        {
            Plane plane = _createdPlanes.First(p => p.Id == planeGuid);
            plane.State = PlaneState.OnService;
            _gsc.SetNeeds(plane.Id, plane.Flight, (plane.Type == PlaneType.Airbus), plane.MaxStandartPassengers,
                plane.MaxVipPassengers, 10, plane.FuelNeed);
        }

        private bool CheckTime(DateTime time)
        {
            // TODO: присоединить к метрологической службе
            return true;
        }
    }
}