using System;
using System.Collections.Generic;
using System.Threading;

namespace PassengerBus
{
    public static class SpecialThead
    {
        private static readonly SynchronizedCollection<CancellationTokenSource> _tokens;

        static SpecialThead()
        {
            _tokens = new SynchronizedCollection<CancellationTokenSource>();
            Metrological.Instance.MessageReceived += CancelTasks;
        }

        private static void CancelTasks(object sender, MetrologicalEventArgs e)
        {
            foreach (CancellationTokenSource cancellationTokenSource in _tokens)
            {
                cancellationTokenSource.Cancel();
            }
        }

        public static void Sleep(int time)
        {
            while (true)
            {
                int sleepTime = Convert.ToInt32(time * Metrological.Instance.CurrentCoef);
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

    }
}