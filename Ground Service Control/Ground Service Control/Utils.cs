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
        {}

        private static readonly Utils m_self = new Utils();

        /// <summary>
        /// Пеобразует настоящее время во внутреннее время системы
        /// </summary>
        /// <returns></returns>
        public int systemTime(int time)
        {
            //TODO: метрологическая служба.
            return time;
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
            //TODO: логгер
        }
    }
}