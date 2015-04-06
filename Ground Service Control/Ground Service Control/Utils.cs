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
        /// Возвращает количество миллесекунд в 1 секунде
        /// </summary>
        /// <returns></returns>
        public int msInSecond()
        {
            //TODO: метрологическая служба.
            return 1000;
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