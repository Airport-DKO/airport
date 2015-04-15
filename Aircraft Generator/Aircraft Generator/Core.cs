﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aircraft_Generator.Commons;
using Aircraft_Generator.FollowMeWs;
using Aircraft_Generator.GmcVs;
using Aircraft_Generator.GscWs2;
using Aircraft_Generator.InformationPanelWS;
using Aircraft_Generator.MetrologicalService;
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
        private readonly FollowMe _followMe;
        private readonly GMC _gmc;
        private readonly GSC _gsc;
        private readonly MetrologService _metrolog;
        private readonly WebServiceInformationPanel _panel;

        private readonly SynchronizedCollection<CancellationTokenSource> _tokens;
        private readonly Tower _tower;

        private Core()
        {
            _createdPlanes = new List<Plane>();
            _tower = new Tower();
            _gmc = new GMC();
            _gsc = new GSC();
            _panel = new WebServiceInformationPanel();
            _metrolog = new MetrologService();
            _followMe = new FollowMe();
            _tokens = new SynchronizedCollection<CancellationTokenSource>();
            Rabbit.Instance.MessageReceived += CancelTasks;
        }

        public List<Plane> Planes
        {
            get { return _createdPlanes; }
        }

        public bool CreateNewPlane(String name, PlaneType type, int fuelNeed,
            int currentStandartPassengers, int currentVipPassengers, bool hasArrivalPassengers, int currentBaggage)
        {
            var plane = new Plane(name, PlaneState.Arrival, type, fuelNeed, currentStandartPassengers,
                currentVipPassengers, currentBaggage, 0, hasArrivalPassengers);
            _createdPlanes.Add(plane);
            Debug.WriteLine("Plane {0} created! Type: {1}. Fuel {2}, StdPas: {3} VipPas: {4} Bugg: {5}", name, type,
                fuelNeed, currentStandartPassengers, currentVipPassengers, currentBaggage);
            Logger.SendMessage(1, "AircraftGenerator", String.Format("Plane {0} created", name),
                _metrolog.GetCurrentTime());
            return true;
        }

        public void BindPlaneToFlight(Guid planeId, Guid flightId)
        {
            Plane plane = Planes.First(p => p.Id == planeId);
            plane.Flight = _panel.RegisterPlaneToFlight(planeId, flightId);
            var task = new Task(() => PlaneLanding(plane));
            Debug.WriteLine("Plane {0} binded to {1}", planeId,flightId);
            Logger.SendMessage(1, "AircraftGenerator", String.Format("Plane {0} binded to {1}", planeId, flightId),
    _metrolog.GetCurrentTime());
            task.Start();
        }

        public bool LoadStandartPassangers(MapObject serviceZone, List<Guid> passengersGuids)
        {
            Plane plane = Planes.First(p => p.ServiceZone.Number == serviceZone.Number);
            plane.CurrentStandartPassengers += passengersGuids.Count;
            return true;
        }

        public bool LoadVipPassangers(MapObject serviceZone, List<Guid> passengersGuids)
        {
            Plane plane = Planes.First(p => p.ServiceZone.Number == serviceZone.Number);
            plane.CurrentVipPassengers += passengersGuids.Count;
            return true;
        }

        public bool UnloadStandartPassangers(MapObject serviceZone, int countOfPassengers)
        {
            Plane plane = Planes.First(p => p.ServiceZone.Number == serviceZone.Number);
            plane.CurrentStandartPassengers -= countOfPassengers;
            return true;
        }

        public bool UnloadVipPassangers(MapObject serviceZone, int countOfPassengers)
        {
            Plane plane = Planes.First(p => p.ServiceZone.Number == serviceZone.Number);
            plane.CurrentVipPassengers -= countOfPassengers;
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
            Debug.WriteLine("Plane {0} is now following", planeId);
            Logger.SendMessage(1, "AircraftGenerator", String.Format("Plane {0} is now following", planeId),
    _metrolog.GetCurrentTime());
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
            Debug.WriteLine("Plane {0} is at Service Zone now", planeId);
            Logger.SendMessage(1, "AircraftGenerator", String.Format("Plane {0} is at Service Zone now", planeId),
    _metrolog.GetCurrentTime());
            return true;
        }

        public bool Douched(MapObject serviceZone)
        {
            // TODO
            return true;
        }

        private void Sleep(int time)
        {
            while (true)
            {
                int sleepTime = Convert.ToInt32(time*Rabbit.Instance.CurrentCoef);
                var tokenSource = new CancellationTokenSource();
                _tokens.Add(tokenSource);
                bool cancelled = tokenSource.Token.WaitHandle.WaitOne(sleepTime);
                _tokens.Remove(tokenSource);
                if (cancelled)
                {
                    continue;
                }
                break;
            }
        }


        private void PlaneLanding(Plane plane)
        {
            while (!CheckTime(plane.Flight.arrivalTime))
            {
                Sleep(10000);
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

            MapObject runway = _gmc.GetRunway();
            plane.State = PlaneState.Landing;
            plane.ServiceZone = _gmc.GetPlaneServiceZone(plane.Id);
            _followMe.LeadPlane(runway, plane.ServiceZone, plane.Id);
            Debug.WriteLine("Plane {0} landed!", plane.Name);
            Logger.SendMessage(1, "AircraftGenerator", String.Format("Plane {0} landed!", plane.Name),
    _metrolog.GetCurrentTime());
        }

        private void CancelTasks(object sender, MetrologicalEventArgs e)
        {
            foreach (CancellationTokenSource cancellationTokenSource in _tokens)
            {
                cancellationTokenSource.Cancel();
            }
        }

        private void PlaneTaxingToServiceZone(Guid planeGuid)
        {
            Plane plane = _createdPlanes.First(p => p.Id == planeGuid);
            plane.State = PlaneState.TaxingToRunway;
            _gmc.RunwayRelease();
        }

        private void PlaneIsReadyToService(Guid planeGuid)
        {
            Plane plane = _createdPlanes.First(p => p.Id == planeGuid);
            plane.State = PlaneState.OnService;
            _gsc.SetNeeds(plane.Id, plane.Flight, (plane.Type == PlaneType.Airbus), plane.CurrentStandartPassengers,
                plane.CurrentVipPassengers, plane.CurrentBaggage, plane.FuelNeed);
        }

        private bool CheckTime(DateTime time)
        {
            DateTime currentAirportTime = _metrolog.GetCurrentTime();
            if (currentAirportTime.AddMinutes(-500) >= time)
            {
                return true;
            }
            return false;
        }
    }
}