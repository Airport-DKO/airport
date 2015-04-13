using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
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
            List<Obj> objects = new List<Obj>
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

            var a = new vis.visualisator();
            char c = '1';

            while (c!='0')
            {

                var o = objects[10];

                a.MoveObject(o.type, o.guid, new vis.CoordinateTuple { X = 8, Y = 8 }, 1);
                Console.WriteLine("Message sent! {0} : {1}", o.type, o.guid);

                System.Threading.Thread.Sleep(1000);
                c = Console.ReadLine()[0];
            }


        }
    }
}
