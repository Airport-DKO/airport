using System;
using System.Collections.Generic;
using System.Linq;
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

        public double temperature()
        {
            //TODO: метеорологическая служба.
            return 20;
        }

        public void log(string message)
        {
            //TODO: логгер
        }
    }
}