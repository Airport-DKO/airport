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
        static public bool Clean(List<CoordinateTuple> coordinates, CancellationToken token)
        {
            var gmc = new GMC.GMC();
            var id = Guid.NewGuid();
            var speed = 500;

            Logger.SendMessage("Начата очистка снега");

            foreach (var coordinate in coordinates)
            {
                var newSpeed = speed*Metrological.Instance.CurrentCoef;
                while (!gmc.Step(coordinate, MoveObjectType.SnowRemovalVehicle, id, newSpeed))
                {
                    if(token.IsCancellationRequested){
                        return true;
                    }
                    Thread.Sleep(Convert.ToInt32(newSpeed)); // todo po chelovecheski sdelat
                }
            }

            gmc.SnowCleanFinished();

            Logger.SendMessage("Очистка снега завершена");

            return true;
        }
    }
}