using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding enc = Encoding.GetEncoding("us-ascii",
                                          new EncoderExceptionFallback(),
                                          new DecoderExceptionFallback());



            var c = new TcpClient("localhost", 9050);
                var steam = c.GetStream();
                var buf = new byte[500];
                var str = "200";
                buf = Encoding.ASCII.GetBytes(str);
                steam.Write(buf, 0, buf.Length);
                var bytes = new byte[50000];
                steam.Read(bytes, 0, 50000);
                
            Console.WriteLine(enc.GetString(bytes));
            
            c.Close();
        }
    }
}
