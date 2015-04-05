using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;
using System.Text.RegularExpressions;

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
        static double AirportTemperature = 4;

        [WebMethod]
        public double GetTemperature()
        {
            return AirportTemperature;
        }

        [WebMethod]
        public void SetTemperature(double t)
        {
            AirportTemperature = t;
        }

        [WebMethod]
        public double GetTempFromCity(string city)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            if (city.Length == 0) return 0;
            WebServiceGlobalWeather.GlobalWeatherSoap ws = new WebServiceGlobalWeather.GlobalWeatherSoapClient();
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
                    continue;
                }
            }
            
            if (xmlCodeString == "Data Not Found")
                return 0;
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
            return temp;
        }

        [WebMethod]
        public int GetWindFromCity(string city)
        {
            if (city.Length == 0) return 0;
            WebServiceGlobalWeather.GlobalWeatherSoap ws = new WebServiceGlobalWeather.GlobalWeatherSoapClient();
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
                    continue;
                }
            }

            if (xmlCodeString == "Data Not Found")
                return 0;
            XDocument xmlCode = XDocument.Parse(xmlCodeString);
            XElement valueElement = xmlCode.Element("CurrentWeather").Element("Wind");
            string valueString = valueElement.Value;
            string pattern = @"[-,0-9,.]+ MPH";
            string text = valueString;
            RegexOptions option = RegexOptions.Singleline;
            Regex newReg = new Regex(pattern, option);
            Match match = newReg.Match(text);
            pattern = @"[-,0-9,.]+";
            text = match.ToString();
            newReg = new Regex(pattern, option);
            match = newReg.Match(text);
            int wind = (int)Math.Round(Double.Parse(match.Value) * 0.45);
            return wind;
        }
        
        [WebMethod]
        public void CrapSnow()
        {

        }
    }
}
