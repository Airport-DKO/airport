﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using BaggageTractor.GscVS;
using MapObject = BaggageTractor.GmcVS.MapObject;

namespace BaggageTractor
{
    /// <summary>
    /// Summary description for BaggageTractor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BaggageTractor : System.Web.Services.WebService
    {
        /// <summary>
        /// Метод, который служит для выгрузки багажа с рейса
        /// </summary>
        /// <param name="serviceZone">площадка, на которой стоит самолет</param>
        /// <param name="weightOfBaggage">количество багажа для выгрузки</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        [WebMethod]
        public bool UnloadBaggage(MapObject serviceZone, int weightOfBaggage, ServiceTaskId taskId)
        {
            var t = new Task(() => Worker.FromPlane(serviceZone, weightOfBaggage, taskId));
            t.Start();//запускаем выполнение асинхронно

            return true;
        }

        /// <summary>
        /// Метод, который служит для загрузки багажа на рейс
        /// </summary>
        /// <param name="serviceZone">площадка, на которой стоит самолет</param>
        /// <param name="flightNumber">номер рейса, багаж пассажиров которого следует погрузить</param>
        /// <param name="taskId">номер задания</param>
        /// <returns></returns>
        [WebMethod]
        public bool LoadBaggage(MapObject serviceZone, Guid flightNumber, ServiceTaskId taskId)
        {
            var t = new Task(() => Worker.ToPlain(serviceZone, flightNumber, taskId));
            t.Start();//запускаем выполнение асинхронно

            return true;
        }

        
        /// <summary>
        /// Метод, который позволяет определить, есть ли багаж у пассажиров на данный рейс
        /// </summary>
        /// <param name="flightNumber">номер рейса, наличие багажа пассажиров которого следует проверить</param>
        /// <returns></returns>
        [WebMethod]
        public bool ToPlain(Guid flightNumber)
        {
            var count = Worker.GetWeightOfBaggage(flightNumber); //запрашиваем количество багажа
            return count > 0; //возвращаем true, если багаж есть
        }
        
    }
}
