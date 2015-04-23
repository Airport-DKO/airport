using System;
using System.Threading;
using System.Collections.Generic;

namespace BaggageTractor
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
            for (int i = 0; i < _tokens.Count; i++)
            {
                _tokens[i].Cancel();
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