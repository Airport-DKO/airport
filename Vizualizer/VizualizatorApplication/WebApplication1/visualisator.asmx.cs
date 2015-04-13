using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Services;
using WebApplication1.Logic;


namespace WebApplication1
{
    /// <summary>
    /// Summary description for visualisator
    /// </summary>
    [WebService(Namespace = "http://airport-dko-1.cloudapp.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class visualisator : System.Web.Services.WebService
    {
        [WebMethod]
        public List<CoordinateTuple> GetMap()
        {
            #region Удалить перед релизом
            Parser.Instance.RefreshMap();
            #endregion

            return Parser.Instance.Map;
        }

        [WebMethod]
        public List<Location> GetMapObjects()
        {
            #region Удалить перед релизом
            Parser.Instance.RefreshMapObjects();
            #endregion

            return Parser.Instance.MapObjects;

        }

        [WebMethod]
        public List<Route> GetRoutes()
        {
            #region Удалить перед релизом
            Parser.Instance.RefreshRoutes();
            #endregion

            return Parser.Instance.Routes;
        }

        [WebMethod]
        public void MoveObject(MoveObjectType type, Guid objectID, CoordinateTuple newPosition, int speed)
        {
            Logic.Server.Instance.SendMessage(String.Format("{0}; {1}; {2}; {3}; {4};", type.ToString(), objectID.ToString(), newPosition.X.ToString(), newPosition.Y.ToString(), speed.ToString()));
        }

        [WebMethod]
        public void LetItSnow()
        {
            Logic.Server.Instance.SendMessage("LetSnow;");
            
        }




    }


}

