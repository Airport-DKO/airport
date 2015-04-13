using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication1.Logic
{
    public class Serializator
    {
        public List<CoordinateTuple> DeserializeMap(string xmlPath)
        {
            var rez = new List<CoordinateTuple>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<CoordinateTuple>));
            StreamReader reader = new StreamReader(xmlPath);

            try
            {
                rez = (List<CoordinateTuple>)deserializer.Deserialize(reader);
            }
            catch
            {
                rez[0] = new CoordinateTuple { X = 0, Y = 0 };
            }

            reader.Close();
            return rez;
        }

        public List<Location> DesrrializeMapObject(string xmlPath)
        {
            var list = new List<Location>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Location>));
            StreamReader reader = new StreamReader(xmlPath);
            try
            {
                list = (List<Location>)deserializer.Deserialize(reader);

            }
            catch
            {
                list[0] = new Location { MapObj = new MapObject { Type = MapObjectType.Airport, number = 1 }, Position = new CoordinateTuple { X = 1, Y = 1 } };
            }
            reader.Close();
            return list;
        }
    }
}