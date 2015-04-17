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
        }

        private static readonly Utils m_self = new Utils();

        /// <summary>
        /// Пеобразует настоящее время во внутреннее время системы
        /// </summary>
        /// <returns></returns>
        public int systemTime(int time)
        {
            return (int)(time * Metrological.Instance.CurrentCoef);
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
            Utils.self().log("Регистрация закончена на: " + plane.GetHashCode());
        }

        public void log(string message)
        {
            Logger.SendMessage(message, 0);
        }

        public void warning(string message)
        {
            Logger.SendMessage(message, 1);
        }
    }
}