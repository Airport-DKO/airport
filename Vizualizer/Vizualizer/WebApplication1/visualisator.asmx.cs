using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using WebApplication1.Logic;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for visualisator
    /// </summary>
    [WebService(Namespace = "http://airport-dko-1.cloudapp.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Visualisator : WebService
    {
        [WebMethod]
        public List<CoordinateTuple> GetMap()
        {
            #region Удалить перед релизом
            Data.Data.Instance.RefreshMap();
            #endregion

            return Data.Data.Instance.Map;
        }

        [WebMethod]
        public List<Location> GetMapObjects()
        {
            #region Удалить перед релизом
            Data.Data.Instance.RefreshMapObjects();
            #endregion

            return Data.Data.Instance.MapObjects;

        }

        [WebMethod]
        public List<Route> GetRoutes()
        {
            #region Удалить перед релизом
            Data.Data.Instance.RefreshRoutes();
            #endregion

            return Data.Data.Instance.Routes;
        }

        [WebMethod]
        public void MoveObject(MoveObjectType type, Guid objectId, CoordinateTuple newPosition, int speed)
        {
            Logic.Server.Instance.SendMessage(string.Format("{0};{1};{2};{3};{4};.", type.ToString(), objectId.ToString(), newPosition.X.ToString(), newPosition.Y.ToString(), speed.ToString()));
        }

        [WebMethod]
        public void LetItSnow()
        {
            Logic.Server.Instance.SendMessage("LetSnow;.");
            
        }

        [WebMethod]
        public void Reset()
        {
            Logic.Server.Instance.SendMessage("Reset.");

        }
    }


}

