using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using Ground_Movement_Control.Commons;

namespace Ground_Movement_Control
{
    /// <summary>
    ///     Summary description for GMC
    /// </summary>
    [WebService(Namespace = "DKO-Airport-Ground-Movement-Control")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GMC : WebService
    {
        [WebMethod]
        public List<CoordinateTuple> GetRoute(MapObject from, MapObject to)
        {
            return Core.Instance.GetRoute(from, to);
        }

        [WebMethod]
        public bool Step(CoordinateTuple coordinate, MoveObjectType type, Guid id)
        {
            return Core.Instance.Step(coordinate.X, coordinate.Y, type, id);
        }
    }
}