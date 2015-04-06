﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Snowplug.GMC;

namespace Snowplug
{
    public class SnowplugTask
    {
        static public bool Clean(List<CoordinateTuple> coordinates)
        {
            var gmc = new GMC.GMC();
            var id = Guid.NewGuid();

            foreach (var coordinate in coordinates)
            {
                while (!gmc.Step(coordinate, MoveObjectType.SnowRemovalVehicle, id))
                {
                    //TODO: Спросить время у службы
                    Thread.Sleep(1000);
                }
            }

            //TODO:
            //gmc.SnowCleanFinished();
            return true;
        }
    }
}