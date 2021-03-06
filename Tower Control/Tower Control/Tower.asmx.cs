﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Tower_Control.GmcWs;

namespace Tower_Control
{
    /// <summary>
    /// Summary description for Tower
    /// </summary>
    [WebService(Namespace = "Airport")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Tower : System.Web.Services.WebService
    {

        [WebMethod]
        public bool LandingRequest(Guid planeId, MoveObjectType type)
        {
            return Core.Instance.LandingRequest(planeId, type);
        }
    }
}
