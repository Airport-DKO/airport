using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace WebApplicationWeather
{
    public class CityWind
    {
        public static Dictionary<string, int> FakeWind = new Dictionary<string, int>();
        private const string ComponentName = "Weather";
        private const int scw = -1;
        static CityWind()
        {
            FakeWind.Add("Tokyo", scw);
            FakeWind.Add("Kyiv", scw);
            FakeWind.Add("Whitecourt", scw);
            FakeWind.Add("Roma", scw);
            FakeWind.Add("Washington", scw);
            FakeWind.Add("Minsk", scw);
            FakeWind.Add("Almaty", scw);
        }
        public void ForceSetWind(string s, int wind)
        {
            FakeWind[s] = wind;
            
        }
        public int GetWindFromCity(string city)
        {
            //Logger.SendMessage(0, ComponentName, String.Format("Запрос ветра из города {0}", city));
            if (city.Length == 0) 
                return 0;
            if (FakeWind[city] != -1)
                return FakeWind[city];
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
            Logger.SendMessage(1, ComponentName, String.Format("Город {0}, ветер {1} м/с", city, wind));
            return wind;
        }
    }
}