using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication5
{
    public class Location
    {
        public CoordinateTuple Position { get; set; }
        public MapObject MapObj { get; set; }
    }

    public class MapObject
    {
        public MapObjectType Type { get; set; }
        public int number { get; set; }
    }

    public enum MapObjectType
    {
        Runway,
        Garage,
        ServiceArea,
        Airport
    }


    [Serializable()]
    public class CoordinateTuple
    {
        private int x;
        [XmlElement("X")]
        public int X
        {
            get { return x; }
            set { x = value;}   
     
        }
        private int y;
        [XmlElement("Y")]
        public int Y
        {
            get { return y; } set { y = value; }
        }
    }

    public class Job
    {
        public List<CoordinateTuple> GetMapFromFile(string path)
        {
            var rez = new List<CoordinateTuple>();

            string[] lines = System.IO.File.ReadAllLines(path);
            for (int j = 0; j < lines.Length; j++)
            {
                Console.WriteLine("\t" + lines[j]);
                for (int i = 0; i < lines[j].Length; i++)
                {
                    if (lines[j][i] == '.' || lines[j][i] == '-' || lines[j][i] == '=')
                    {
                        rez.Add(new CoordinateTuple { X = i, Y = j });
                    }
                }
            }
            return rez;

        }

        public List<Location> GetLocationFromFile(string path)
        {
            var rez = new List<Location>();

            string[] lines = System.IO.File.ReadAllLines(path);
            for (int j = 0; j < lines.Length; j++)
            {
                Console.WriteLine("\t" + lines[j]);
                for (int i = 0; i < lines[j].Length; i++)
                {
                    switch (lines[j][i])
                    {
                        case 'x':
                            rez.Add(new Location { MapObj = new MapObject { Type = MapObjectType.ServiceArea, number = 1 }, Position = new CoordinateTuple { X = i, Y = j } });
                            break;
                        case 'b':
                            rez.Add(new Location { MapObj = new MapObject { Type = MapObjectType.Garage, number = 1 }, Position = new CoordinateTuple { X = i, Y = j } });
                            break;
                        case 'p':
                            rez.Add(new Location { MapObj = new MapObject { Type = MapObjectType.Garage, number = 2 }, Position = new CoordinateTuple { X = i, Y = j } });
                            break;
                        case '#':
                            rez.Add(new Location { MapObj = new MapObject { Type = MapObjectType.Airport, number = 1 }, Position = new CoordinateTuple { X = i, Y = j } });

                            break;
                        case 'r':
                            rez.Add(new Location { MapObj = new MapObject { Type = MapObjectType.Runway, number = 1 }, Position = new CoordinateTuple { X = i, Y = j } });
                            break;
                        default:
                            break;
                    }
                }
            }
            return rez;
        }

        public void SerializeMap(List<CoordinateTuple> map, string path)
        {
            XmlSerializer serializer = new XmlSerializer(map.GetType());
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, map);
            writer.Close();
        }

        public List<CoordinateTuple> DeserializeMap(string xmlPath)
        {
            List<CoordinateTuple> list = new List<CoordinateTuple>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<CoordinateTuple>));
            StreamReader reader = new StreamReader(xmlPath);
            list = (List<CoordinateTuple>)deserializer.Deserialize(reader);
            reader.Close();
            return list;
        }

        public void SerializeMapObjects(List<Location> locations, string path)
        {
            XmlSerializer serializer = new XmlSerializer(locations.GetType());
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, locations);
            writer.Close();
        }

        public List<Location> DesrrializeMapObject(string xmlPath)
        {
            var list = new List<Location>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Location>));
            StreamReader reader = new StreamReader(xmlPath);
            list = (List<Location>)deserializer.Deserialize(reader);
            reader.Close();
            return list;
        }

        public string GetMapString(List<CoordinateTuple> listMap, List<Location> listMapObject)
        {
            
            int maxX = 0;
            int maxY = 0;
            foreach (var elem in listMap)
            {
                if (elem.X > maxX) maxX = elem.X;
                if (elem.Y > maxY) maxY = elem.Y;
            }

            foreach (var elem in listMapObject)
            {
                if (elem.Position.X > maxX) maxX = elem.Position.X;
                if (elem.Position.Y > maxY) maxY = elem.Position.Y;
            }

            char[] rez = new char[(maxX + 1) * maxY +1];
            int count = 0;
            for (int i =0; i< maxY; i++)
            {
                for(int j = 0; j > maxX; j++)
                {
                    rez[count] = '0';
                    count++;
                }
                rez[count] += '\n';
                count++;
            }

            foreach (var elem in listMap)
            {
                int x = elem.X;
                int y = elem.Y;
                int z = (x + 1) * (y) + x;
                try
                { rez[z] = '.'; }
                catch
                { Console.WriteLine("MAX: {0}, {1}", x, y); }
            }

            foreach (var elem in listMapObject)
            {
                int x = elem.Position.X;
                int y = elem.Position.Y;
                int z = (x + 1) * (y) + x;
                switch (elem.MapObj.Type)
                {
                    case MapObjectType.Airport:
                        try
                        { rez[z] = '#'; }
                        catch
                        { Console.WriteLine("MAX: {0}, {1}", x, y); }
                        break;
                    case MapObjectType.Garage:
                        try
                        { rez[z] = 'p'; }
                        catch
                        { Console.WriteLine("MAX: {0}, {1}", x, y); }
                        break;
                    case MapObjectType.ServiceArea:
                        try
                        { rez[z] = 'x'; }
                        catch
                        { Console.WriteLine("MAX: {0}, {1}", x, y); }
                        break;
                    default:
                        break;
                }
                
            }
            return new string(rez);
        }
    }

    class Program 
    {
        
        

        static void Main(string[] args)
        {
            var job = new Job();
            List<CoordinateTuple> mapList = job.GetMapFromFile(@"C:\Vizualizator\map.txt");
            job.SerializeMap(mapList, @"Map.xml");
            var map = job.DeserializeMap(@"Map.xml");
            foreach(var el in map)
            {
                Console.WriteLine("{0} : {1}", el.X, el.Y);
            }

            var mapObj = job.GetLocationFromFile(@"C:\Vizualizator\map.txt");
            job.SerializeMapObjects(mapObj, @"MapObjects.xml");
            var mapObject = job.DesrrializeMapObject(@"MapObjects.xml");

            foreach (var el in mapObject)
            {
                Console.WriteLine("{0} : {1} : {2} : {3}", el.MapObj.Type.ToString(), el.MapObj.number.ToString(), el.Position.X.ToString(), el.Position.Y.ToString());
            }

            Console.WriteLine("{0}", job.GetMapString(map, mapObject));

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

    }
}
