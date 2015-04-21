using System;
using Tower_Control.GmcWs;

namespace Tower_Control
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

        private readonly GMC _groundMovementControl;
        private Core()
        {
            _groundMovementControl=new GMC();
        }

        public bool LandingRequest(Guid planeId)
        {
            return _groundMovementControl.CheckRunwayAwailability(planeId, true);
        }
    }
}