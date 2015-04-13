using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Logic
{
    public static class MyMap
    {
        public static List<CoordinateTuple> GetMap()
        {
            var ser = new Serializator();
            //Заглушка. Будет из файла
            return ser.DeserializeMap(@"C:\Vizualizator\Map.xml");
            
        }

        public static string GetStringMap()
        {
            return "=======================================\n+++++++++++++++++++++++++++++++++++++++\n=======================================\n    .                          .\n    .                          .\n    .                          .\n    .                          .\n    .                          .\n    .                          .\n    .                          .\n.......................................\n.......................................\n.......................................\nxxxxxxxxxx......................ppppppp\nxxxxxxxxxx......................ppppppp\nxxxxxxxxxx....bbbbbb............ppppppp\nxxxxxxxxxx....bbbbbb...#####....ppppppp\n#######################################\n#######################################\n#######################################";
        }
    }
}