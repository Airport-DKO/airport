﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aircraft_Generator.Commons;
using Aircraft_Generator.GmcVs;
using Aircraft_Generator.GscWs2;
using Aircraft_Generator.InformationPanelWS;
using Aircraft_Generator.MetrologicalService;
using Aircraft_Generator.TowerService;
using Cities = Aircraft_Generator.InformationPanelWS.Cities;
using Flight = Aircraft_Generator.InformationPanelWS.Flight;
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
        private readonly MetrologService _metrolog;
        private readonly WebServiceInformationPanel _panel;
        private readonly Tower _tower;

        private Core()
        {
            _createdPlanes = new List<Plane>();
            _tower = new Tower();
            _gmc = new GMC();
            _gsc = new GSC();
            _panel = new WebServiceInformationPanel();
            _metrolog = new MetrologService();
        }

        public List<Plane> Planes
        {
            get { return _createdPlanes; }
        }

        public bool CreateNewPlane(String name, PlaneType type, int fuelNeed,
            int currentStandartPassengers, int currentVipPassengers, bool hasArrivalPassengers, int currentBaggage)
        {
            //DEBUG
            Flight[] fl = GetActualFlights();
            Flight f = fl.First();

            var plane = new Plane(name, PlaneState.Arrival, type, fuelNeed, currentStandartPassengers,
                currentVipPassengers, currentBaggage, 0, hasArrivalPassengers);
            plane.Flight = _panel.RegisterPlaneToFlight(plane.Id, f.number);
            _createdPlanes.Add(plane);
            var task = new Task(() => PlaneLanding(plane));
            task.Start();
            return true;
        }

        public Flight[] GetActualFlights()
        {
            _panel.CreateFlight(DateTime.Now, DateTime.Now.AddMinutes(60), Cities.Antananarivo, 200, 20);
            Flight[] test = _panel.GetAvailableFlights();
            return test;
        }

        public bool LoadPassangers(MapObject serviceZone, List<Guid> passengersGuids)
        {
            Plane plane = Planes.First(p => p.ServiceZone.Number == serviceZone.Number);
            plane.CurrentStandartPassengers += passengersGuids.Count;
            return true;
        }

        public bool UnloadPassangers(MapObject serviceZone, int countOfPassengers)
        {
            Plane plane = Planes.First(p => p.ServiceZone.Number == serviceZone.Number);
            plane.CurrentStandartPassengers -= countOfPassengers;
            return true;
        }

        public bool LoadBaggage(MapObject serviseZone, int weightOfBaggage)
        {
            Plane plane = Planes.First(p => p.ServiceZone.Number == serviseZone.Number);
            plane.CurrentBaggage += weightOfBaggage;
            return true;
        }

        public bool UnloadBaggage(MapObject serviseZone, int weightOfBaggage)
        {
            Plane plane = Planes.First(p => p.ServiceZone.Number == serviseZone.Number);
            plane.CurrentBaggage -= weightOfBaggage;
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

            while (true)
            {
                bool landingRequest = _tower.LandingRequest(plane.Id);
                if (!landingRequest)
                {
                    Sleep(10000);
                }
                else
                {
                    break;
                }
            }

            plane.State = PlaneState.Landing;
            plane.ServiceZone = _gmc.GetPlaneServiceZone(plane.Id);
        }

        private void PlaneTaxingToServiceZone(Guid planeGuid)
        {
            Plane plane = _createdPlanes.First(p => p.Id == planeGuid);
            plane.State = PlaneState.TaxingToRunway;
            _gmc.RunwayRelease();
        }

        private void PlaneIsReadyToService(Guid planeGuid)
        {
            var plane = _createdPlanes.First(p => p.Id == planeGuid);
            plane.State = PlaneState.OnService;
            _gsc.SetNeeds(plane.Id, plane.Flight, (plane.Type == PlaneType.Airbus), plane.CurrentStandartPassengers,
                plane.CurrentVipPassengers, plane.CurrentBaggage, plane.FuelNeed);
        }

        private bool CheckTime(DateTime time)
        {
            DateTime currentAirportTime = _metrolog.GetCurrentTime();
            if (currentAirportTime.AddMinutes(2) >= time)
            {
                return true;
            }
            return false;
        }
    }
}