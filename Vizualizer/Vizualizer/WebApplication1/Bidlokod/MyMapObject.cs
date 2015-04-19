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
            var ser = new Serializator();
            //Из файла, Конечно тоже
            return ser.DesrrializeMapObject(@"C:\Vizualizator\MapObjects.xml");
        }
    }
}