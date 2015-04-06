using System;

namespace Ground_Movement_Control.Commons
{
    public class MapPoint
    {
        private readonly object _lockObject;
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public MapPointState State { get; set; }
        public MoveObjectType OwnerType { get; set; }
        public Guid OwnerGuid { get; set; }
        public bool IsPublicPlace { get; set; }

        public MapPoint(int x, int y)
        {
            X = x;
            Y = y;
            State = MapPointState.Vacant;
            OwnerType=MoveObjectType.None;
            OwnerGuid = Guid.Empty;
            IsPublicPlace = false;
            _lockObject=new object();
        }

        public void MakeVacant()
        {
            State=MapPointState.Vacant;
            OwnerGuid = Guid.Empty;
            OwnerType = MoveObjectType.None;
        }

        public bool TryMove(MoveObjectType ownersType, Guid ownersGuid)
        {
            if (IsPublicPlace)
            {
                return true;
            }
            lock (_lockObject)
            {
                if (State == MapPointState.Vacant)
                {
                    State=MapPointState.Hold;
                    OwnerGuid = ownersGuid;
                    OwnerType = ownersType;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}