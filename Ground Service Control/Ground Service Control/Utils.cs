using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Ground_Service_Control
{
    public class Utils
    {
        static public Utils self()
        {
            return m_self;
        }

        private Utils()
        {
            m_queue = new MessageQueue();
            m_timeService = new MetrologService.MetrologService();
        }

        private static readonly Utils m_self = new Utils();

        /// <summary>
        /// Пеобразует настоящее время во внутреннее время системы
        /// </summary>
        /// <returns></returns>
        public int systemTime(int time)
        {
            return (int)(time / m_timeService.GetCurrentTick());
        }

        /// <summary>
        /// Ждёт указанное кол-во времени (время автоматически переводится в системное)
        /// </summary>
        /// <param name="time"></param>
        public void sleep(int time)
        {
            while(time >= 0){
                Thread.Sleep(Utils.self().systemTime(1000));
                time -= 1000;
            }
        }

        /// <summary>
        /// Ждёт, покарегистрация на самолёт не завершится
        /// </summary>
        /// <param name="plane"></param>
        public void waitTillCheckInFinished(Guid plane)
        {
            var tablo = new WebServiceInformationPanel.WebServiceInformationPanel();
            while (!tablo.IsCheckInFinished(plane))
            {
                Thread.Sleep(Utils.self().systemTime(1000));
            }
        }

        public void log(string message)
        {
            //TODO: Uncomment
            //m_queue.queueMessage(message, m_timeService.GetCurrentTime());
        }

        private MessageQueue m_queue = null;
        private MetrologService.MetrologService m_timeService = null;
    }
}