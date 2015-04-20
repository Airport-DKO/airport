using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var c = new TcpClient("airport-dko-1.cloudapp.net", 9050);
            Encoding enc = Encoding.GetEncoding("us-ascii");


            var steam = c.GetStream();
            var buf = new byte[500];
            var str = "200";
            buf = Encoding.ASCII.GetBytes(str);
            steam.Write(buf, 0, buf.Length);
            var bytes = new byte[50000];
            steam.Read(bytes, 0, 50000);

            var rezstr = enc.GetString(bytes);
            rezstr = rezstr.Trim('\0');
            Console.WriteLine(rezstr);

            c.Close();

            //var steam2 = c.GetStream();
            //var buf2 = new byte[500];
            //var str2 = "201";
            //buf2 = Encoding.ASCII.GetBytes(str2);
            //steam2.Write(buf2, 0, buf2.Length);
            //while (true)
            //{
            //    var recbytes = new byte[50000];
            //    steam.Read(recbytes, 0, 50000);

            //    var recstr = enc.GetString(recbytes);
            //    recstr = recstr.Trim('\0');
            //    Console.WriteLine(recstr);

            //}

            c.Close();


            //while (true)
            //{
            //    var steam = c.GetStream();
            //    var bytes = new byte[50000];
            //    steam.Read(bytes, 0, 50000);
            //    var str = enc.GetString(bytes);
            //    str = str.Trim('\0');
            //    Console.WriteLine(str);
            //}
            //c.Close();
        }
    }
}
