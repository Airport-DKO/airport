using System;
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

            Logger.SendMessage("Начата очистка снега");

            foreach (var coordinate in coordinates)
            {
                while (!gmc.Step(coordinate, MoveObjectType.SnowRemovalVehicle, id))
                {
                    Thread.Sleep(1000 * (int)Metrological.Instance.CurrentCoef);
                }
            }

            //TODO:
            //gmc.SnowCleanFinished();

            Logger.SendMessage("Очистка снега окончена");

            return true;
        }
    }
}