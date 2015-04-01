﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using FollowMe.GmcVS;

namespace FollowMe
{
    /// <summary>
    /// Summary description for FollowMe
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FollowMe : System.Web.Services.WebService
    {
        /// <summary>
        /// Метод, который вызывает машину Follow Me
        /// </summary>
        /// <param name="from">место, где необходимо встретить самолет</param>
        /// <param name="to">место, куда необходимо привести самолет</param>
        /// <returns></returns>
        [WebMethod]
        public bool LeadPlane(MapObject from, MapObject to)
        {
            Worker.LeadPlane(from,to);
            //TODO: В КОНЦЕ СООБЩИТЬ ГС ИЛИ УНД, ЧТОБ САМОЛЕТ ЗНАЛ, ЧТО ОН ПРИБЫЛ НА ТОЧКУ?
            return true;
        }
    }
}
