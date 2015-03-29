using System;
using System.Collections.Generic;
using Aircraft_Generator.Commons;

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
    }
}