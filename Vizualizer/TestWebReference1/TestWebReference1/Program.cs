using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestWebReference1.vis;

namespace TestWebReference1
{
    class Obj
    {
        public vis.MoveObjectType type;
        public Guid guid;
        public vis.CoordinateTuple coord;

    }
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var objects = new List<Obj>
            {
                #region bidlo
                new Obj
                {
                    type = vis.MoveObjectType.BaggageTractor,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                },
                new Obj
                {
                    type = vis.MoveObjectType.CateringTruck,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                },

                new Obj
                {
                    type = vis.MoveObjectType.ContainerLoader,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                },

                new Obj
                {
                    type = vis.MoveObjectType.Deicer,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                },

                new Obj
                {
                    type = vis.MoveObjectType.FollowMeVan,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                },

                new Obj
                {
                    type = vis.MoveObjectType.None,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                },

                new Obj
                {
                    type = vis.MoveObjectType.PassengerBus,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                },

                new Obj
                {
                    type = vis.MoveObjectType.PassengerStairs,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                },

                new Obj
                {
                    type = vis.MoveObjectType.Plane,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                },
                new Obj
                {
                    type = vis.MoveObjectType.SnowRemovalVehicle,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                },
                new Obj
                {
                    type = vis.MoveObjectType.VipShuttle,
                    guid = new System.Guid((uint)rnd.Next(100), (ushort)rnd.Next(100), (ushort)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100), (byte)rnd.Next(100)),
                    coord = new vis.CoordinateTuple()

                }
                #endregion

            };
            var a = new Visualisator();
            var incStr = "-1";
            while (incStr != "0")
            {
                Console.Clear();
                Console.WriteLine("1 - GetMap, 2 - GetMapObjects, 3 - GetRoutes, \n 4 - SendCar, 5 - Send N Cars, 6 - LetSnow, 7 - Reset");
                incStr = Console.ReadLine();
                switch (incStr)
                {
                    case "1":
                        var coords = a.GetMap();
                        foreach (var coord in coords)
                        {
                            Console.WriteLine("x: {0} \t y: {1}", coord.X, coord.Y);
                        }
                        break;
                    case "2":
                        var locations = a.GetMapObjects();
                        foreach (var location in locations)
                        {
                            Console.WriteLine("{0}.{1}, X:{1}, Y:{2}", location.MapObj.Type, location.MapObj.number, location.Position.X, location.Position.Y);
                        }
                        break;
                    case "3":
                        var routes = a.GetRoutes();
                        foreach (var route in routes)
                        {
                            Console.WriteLine("From: {0}.{1} \t-> To {2}.{3}", route.From.MapObj.Type, route.From.MapObj.number, route.To.MapObj.Type, route.To.MapObj.number);
                        }
                        break;
                    case "4":
                        var car = objects[rnd.Next(11)];
                        int x = rnd.Next(25);
                        int y = rnd.Next(25);
                        a.MoveObject(car.type, car.guid, new CoordinateTuple {X = x, Y = y}, rnd.Next(3000));
                        Console.WriteLine("car :{0} send to x:{1} y:{2}", car.type, x, y);
                        break;
                    case "5":
                        Console.WriteLine("How Much");
                        var n = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            var car1 = objects[rnd.Next(11)];
                            int x1 = rnd.Next(25);
                            int y1 = rnd.Next(25);
                            a.MoveObject(car1.type, car1.guid, new CoordinateTuple { X = x1, Y = y1 }, rnd.Next(3000));
                            Console.WriteLine("car :{0} send to x:{1} y:{2}", car1.type, x1, y1);
                            System.Threading.Thread.Sleep(100);
                        }
                        break;
                    case "6":
                        a.LetItSnow();
                        Console.WriteLine("Snow!");
                        break;
                    case "7":
                        a.Reset();
                        Console.Write("Reseted");
                        break;
                }
                Console.WriteLine("0 - EXIT");
                incStr = Console.ReadLine();
            }

            

            
        }
    }
}
