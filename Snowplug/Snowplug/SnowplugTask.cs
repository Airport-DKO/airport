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
                while (!gmc.Step(coordinate, MoveObjectType.SnowRemovalVehicle, id, speed * (int)Metrological.Instance.CurrentCoef))
                {
                    if(token.IsCancellationRequested){
                        return true;
                    }
                    Thread.Sleep(speed * (int)Metrological.Instance.CurrentCoef);
                }
            }

            gmc.SnowCleanFinished();

            Logger.SendMessage("Очистка снега завершена");

            return true;
        }
    }
}