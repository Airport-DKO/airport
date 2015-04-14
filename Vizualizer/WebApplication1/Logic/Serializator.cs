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
        public List<CoordinateTuple> DeserializeMap(string path)
        {
            var rez = new List<CoordinateTuple>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<CoordinateTuple>));
            StreamReader reader = new StreamReader(path);

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
    }
}