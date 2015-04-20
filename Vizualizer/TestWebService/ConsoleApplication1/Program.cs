using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class Program
    {
        

        static void Main(string[] args)
        {
            var a = new visual2.visualisator();

            visual2.Route[] list = a.GetRoutes();

            foreach(var item in list)
            {
                Console.WriteLine("from: {0}.{1} to: {2}.{3}", item.From.MapObj.Type.ToString(),item.From.MapObj.number, item.To.MapObj.Type.ToString(), item.To.MapObj.number.ToString());
            }

            
            
            //a.LetItSnow();
        }
    }
}
