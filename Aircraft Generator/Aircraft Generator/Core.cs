using System;
using System.Collections.Generic;
using Aircraft_Generator.Commons;
using Aircraft_Generator.GmcVs;
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

        public List<Plane> Planes { get { return _createdPlanes; } }

        private Core()
        {
            _createdPlanes = new List<Plane>();
        }

        public bool CreateNewPlane(String name, PlaneType type, int fuelNeed,
            int maxStandartPassengers, int maxVipPassengers, bool hasArrivalPassengers)
        {
            _createdPlanes.Add(new Plane(name, PlaneState.Arrival, type, fuelNeed, maxStandartPassengers, maxVipPassengers, hasArrivalPassengers));
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
            //TODO: Needed realization
            return true;
        }

        public bool DoStep(Guid planeId, CoordinateTuple step)
        {
            // TODO: Needed realization
            return true;
        }

        public bool FollowMeComplete(Guid planeId)
        {
            // TODO: Needed realization
            return true;
        }
    }
}