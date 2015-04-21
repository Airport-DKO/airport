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
            List<CoordinateTuple> rez;
            var deserializer = new XmlSerializer(typeof(List<CoordinateTuple>));
            var reader = new StreamReader(xmlPath);
            try
            {
                rez = (List<CoordinateTuple>)deserializer.Deserialize(reader);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            reader.Close();
            return rez;
        }
        public List<Route> DeserializeRoute(string xmlPath)
        {
            List<Route> rez;
            var deserializer = new XmlSerializer(typeof(List<Route>));
            var reader = new StreamReader(xmlPath);

            try
            {
                rez = (List<Route>)deserializer.Deserialize(reader);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            reader.Close();
            return rez;
        }

        public List<Location> DesrrializeMapObject(string xmlPath)
        {
            List<Location> list;
            var deserializer = new XmlSerializer(typeof(List<Location>));
            var reader = new StreamReader(xmlPath);
            try
            {
                list = (List<Location>)deserializer.Deserialize(reader);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            reader.Close();
            return list;
        }
    }
}