using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;
using System.Text.RegularExpressions;

using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Events;

namespace WebApplicationWeather
{
    /// <summary>
    /// Сводное описание для WebServiceWeather
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]

    public class WebServiceWeather : System.Web.Services.WebService
    {
        static double AirportTemperature = 5;
        static bool Finish = true;
        private const string ComponentName = "Weather";
        GMC.GMC gmc = new GMC.GMC();
        CityWind Wind = new CityWind();

        [WebMethod]
        public double GetTemperature(bool gui)
        {
            if (gui)
                Logger.SendMessage(0, ComponentName, String.Format("Aэропорт, температура {0} С", AirportTemperature));
            else
                Logger.SendMessage(1, ComponentName, String.Format("Aэропорт, температура {0} С", AirportTemperature));
            return AirportTemperature;
        }


        [WebMethod]
        public void SetTemperature(double t)
        {
            AirportTemperature = t;
            Logger.SendMessage(1, ComponentName, String.Format("Aэропорт, установлена температура {0} С", AirportTemperature));
        }

        [WebMethod]
        public double GetTempFromCity(string city)
        {
            Logger.SendMessage(0, ComponentName, String.Format("Запрос температуры из города {0}", city));
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            if (city.Length == 0) return 0;
            WSGW.GlobalWeather ws = new WSGW.GlobalWeather();
            string xmlCodeString;
            while (true)
            {
                try
                {
                    xmlCodeString = ws.GetWeather(city, "");
                    break;
                }
                catch
                {
                    Logger.SendMessage(0, ComponentName, String.Format("{0}, повтор запроса", city));
                    continue;
                }
            }

            if (xmlCodeString == "Data Not Found")
            {
                Logger.SendMessage(0, ComponentName, String.Format("Информация о погоде в городе {0} не предоставляется", city));
                return 0;
            }
            XDocument xmlCode = XDocument.Parse(xmlCodeString);
            XElement valueElement = xmlCode.Element("CurrentWeather").Element("Temperature");
            string valueString = valueElement.Value;
            string pattern = @"[-,0-9,.]+ C";
            string text = valueString;
            RegexOptions option = RegexOptions.Singleline;
            Regex newReg = new Regex(pattern, option);
            Match match = newReg.Match(text);
            pattern = @"[-,0-9,.]+";
            text = match.ToString();
            newReg = new Regex(pattern, option);
            match = newReg.Match(text);
            double temp = Double.Parse(match.Value);
            Logger.SendMessage(1, ComponentName, String.Format("Город {0}, температура {1} С", city, temp));
            return temp;
        }

        [WebMethod]
        public int GetWindFromCity(string city)
        {
            //Логгирование происходит внутри метода
            return Wind.GetWindFromCity(city);
        }

        [WebMethod]
        public bool GetFinishCondition()
        {
            //Логгирование не требуется
            return Finish;
        }

        [WebMethod]
        public void Finished()
        {
            Finish = true;
            Logger.SendMessage(0, ComponentName, String.Format
                ("Сообщение об отчистки от снега получено"));
        }

        [WebMethod]
        public void SetWind(string city, int wind)
        {
            Wind.ForceSetWind(city, wind);
            if (wind == -1)
                Logger.SendMessage(1, ComponentName, String.Format
                ("Город {0}, ложная скорость ветра сброшена", city));
            else 
                Logger.SendMessage(1, ComponentName, String.Format
                ("Город {0}, установлена ложная скорость ветра: {1} м/с", city, wind));
        }

        [WebMethod]
        public void CrapSnow()
        {
            //Logger.SendMessage(0, ComponentName, String.Format("Снег начинает падать"));
            Finish = false;
            gmc.LetitSnow();
            Logger.SendMessage(1, ComponentName, String.Format("Снег выпал"));
        }
    }
}
