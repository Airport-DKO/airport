using System;
using System.Threading;
using System.Threading.Tasks;
using FollowMe.GmcVS;

namespace FollowMe
{
    public static class FollowMeProxy
    {
        public static CancellationTokenSource CancellationTokenSource;

        static FollowMeProxy()
        {
            CancellationTokenSource = new CancellationTokenSource();
        }

        public static bool LeadPlane(MapObject from, MapObject to, Guid planeId)
        {
            Task t = new Task(() => Worker.LeadPlane(from, to, planeId), CancellationTokenSource.Token);
            t.Start();

            return true;
        }

        public static void Reset()
        {
            CancellationTokenSource.Cancel();
            CancellationTokenSource = new CancellationTokenSource();
        }
    }
}