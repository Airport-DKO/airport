using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Logic;

namespace WebApplication1.Bidlokod
{
    public static class MyMapObject
    {
        public static List<Location> GetMapObjects()
        {
            //Из файла, Конечно тоже
            return new List<Location> { new Location { Position = new CoordinateTuple { X = 1, Y = 2 }, MapObj = new MapObject { Type = MapObjectType.Airport, number = 1 } } };
        }
    }
}