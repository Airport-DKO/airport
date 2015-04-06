﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using Snowplug.GMC;

namespace Snowplug
{
    /// <summary>
    /// Summary description for Snowplug
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Snowplug : System.Web.Services.WebService
    {
        /// <summary>
        /// УНД командует Снегоочистке убрать снег с карты
        /// </summary>
        /// <param name="coordinates">Путь, чтобы проехать по всей карте</param>
        /// <returns></returns>
        [WebMethod]
        public bool Clean(List<CoordinateTuple> coordinates)
        {
            var t = new Task(() => SnowplugTask.Clean(coordinates));
            t.Start();

            return true;
        }

        //FIXME: как сообщить, что операция завершена?
    }
}
