using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Ground_Service_Control.GMC;
using Ground_Service_Control.AircraftGenerator;

namespace Ground_Service_Control
{
    /// <summary>
    /// Summary description for GSC
    /// </summary>
    [WebService(Namespace = "DKO-Airport-Ground-Service-Control")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GSC : System.Web.Services.WebService
    {
        /// <summary>
        /// УНД запрашивает у УНО место обслуживания (самолёт хочет зайти на посадку)
        /// </summary>
        /// <param name="plane">Самолёт, который хочет призtмлиться</param>
        /// <returns>Площадку для приземления или null</returns>
        [WebMethod]
        MapObject GetFreePlace(Guid plane)
        {
            //FIXME:
            return null;
        }

        /// <summary>
        /// Г.С. передает перечень необходимых самолету услуг + рейс (самолёт прилетел)
        /// </summary>
        /// <param name="plane">Самолёт</param>
        /// <param name="flight">Рейс</param>
        /// <param name="ladder">Нужен ли трап</param>
        /// <param name="economPassengers">Количество пассажиров</param>
        /// <param name="VIPPassengers">Количество VIP пассажиров</param>
        /// <param name="baggage">Количество багажа</param>
        /// <param name="fuelingNeeds">Сколько нужно дозаправить топлива</param>
        /// <returns>true</returns>
        [WebMethod]
        bool SetNeeds(Guid plane, Flight flight, bool ladder, int economPassengers, int VIPPassengers,
            int baggage, int fuelingNeeds)
        {
            //FIXME:
            return true;
        }

        /// <summary>
        /// Выполнив задание, службы сообщают, что миссия выполнена
        /// </summary>
        /// <param name="TaskNumber">Номер задачи, которая была назначена УНО</param>
        /// <returns>true</returns>
        [WebMethod]
        bool Done(int TaskNumber)
        {
            //FIXME:
            return true;
        }
    }
}
