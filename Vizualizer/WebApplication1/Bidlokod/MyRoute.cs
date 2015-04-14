using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Logic;

namespace WebApplication1.Bidlokod
{
    public static class MyRoute
    {
        public static List<Route> GetRoute()
        {
            //Из файла
            return new List<Route>
            {
                new Route {
                    From = new Location { Position = new CoordinateTuple { X = 1, Y = 1}, MapObj = new MapObject { Type = MapObjectType.Airport, number = 1} },
                    To = new Location { Position =  new CoordinateTuple { X = 1, Y = 3}, MapObj = new MapObject { Type = MapObjectType.Garage, number = 1 } },
                    Points = new List<CoordinateTuple> { new CoordinateTuple { X = 1, Y = 1}, new CoordinateTuple { X = 1, Y = 2}, new CoordinateTuple { X = 1, Y = 3} }
                } ,
                new Route {
                    From = new Location { Position = new CoordinateTuple { X = 1, Y = 1}, MapObj = new MapObject { Type = MapObjectType.Garage, number = 1} },
                    To = new Location { Position =  new CoordinateTuple { X = 3, Y = 1}, MapObj = new MapObject { Type = MapObjectType.Airport, number = 1 } },
                    Points = new List<CoordinateTuple> { new CoordinateTuple { X = 1, Y = 1}, new CoordinateTuple { X = 2, Y = 1}, new CoordinateTuple { X = 3, Y = 1} }
                }
            };
        }
    }
}