using System;
using System.Collections.Generic;
using Aircraft_Generator.Commons;
using Aircraft_Generator.TowerControl;

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

        public bool CheckInPassengers(List<Guid> passengersGuids)
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
    }
}