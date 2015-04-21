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
            var enc = Encoding.GetEncoding("us-ascii");

            Console.WriteLine("1 - Map, 2 - Get Objects");
            var s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    var str = "200";
                    var buf = Encoding.ASCII.GetBytes(str);
                    c.GetStream().Write(buf, 0, buf.Length);
                    var bytes = new byte[50000];
                    c.GetStream().Read(bytes, 0, 50000);

                    var rezstr = enc.GetString(bytes).Trim('\0');
                    Console.WriteLine(rezstr);
                    break;
                case "2":
                    var str2 = "201";
                    var buf2 = Encoding.ASCII.GetBytes(str2);
                    c.GetStream().Write(buf2, 0, buf2.Length);
                    while (true)
                    {
                        var recbytes = new byte[50000];
                        c.GetStream().Read(recbytes, 0, 50000);

                        var recstr = enc.GetString(recbytes).Trim('\0');
                        Console.WriteLine(recstr);

                    }
            }
            c.Close();
        }
    }
}
