﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aircraft_Generator.Commons;
using Aircraft_Generator.GmcVs;
using Aircraft_Generator.GscWs;
using Aircraft_Generator.TowerControl;
using MapObject = Aircraft_Generator.TowerControl.MapObject;

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
        private readonly Tower _tower;
        private readonly GMC _gmc;
        private readonly GSC _gsc;

        public List<Plane> Planes { get { return _createdPlanes; } }

        private Core()
        {
            _createdPlanes = new List<Plane>();
            _tower= new Tower();
            _gmc = new GMC();
            _gsc=new GSC();
        }

        public bool CreateNewPlane(String name, PlaneType type, int fuelNeed,
            int maxStandartPassengers, int maxVipPassengers, bool hasArrivalPassengers)
        {
            var plane = new Plane(name, PlaneState.Arrival, type, fuelNeed, maxStandartPassengers, maxVipPassengers,
                hasArrivalPassengers);
            _createdPlanes.Add(plane);
            var task = new Task(()=>PlaneLanding(plane));
            task.Start();
            return true;
        }

        public bool LoadPassangers(MapObject serviceZone, List<Guid> passengersGuids)
        {
            //TODO Needed realization
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
                var result = _gmc.Step(step, MoveObjectType.Plane, planeId);
                if (result)
                {
                    break;
                }
                else
                {
                    Sleep(1000);
                }
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
            int sleepTime = Convert.ToInt32(time * GetTimeCoef());
            Thread.Sleep(sleepTime);
        }

        private void PlaneLanding(Plane plane)
        {
            while (!CheckTime(plane.Flight.ArrivalTime))
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

            plane.State=PlaneState.Landing;
        }

        private void PlaneTaxingToServiceZone(Guid planeGuid)
        {
            var plane = _createdPlanes.First(p => p.Id == planeGuid);
            plane.State=PlaneState.TaxingToRunway;
            // TODO: Сообщить GMC о том, что полоса освободилась

        }

        private void PlaneIsReadyToService(Guid planeGuid)
        {
            var plane = _createdPlanes.First(p => p.Id == planeGuid);
            plane.State=PlaneState.OnService;
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