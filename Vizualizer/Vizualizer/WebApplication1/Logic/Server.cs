using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace WebApplication1.Logic
{
    public class Server
    {
        #region Singleton_realization

        private static readonly Lazy<Server> _instance =
            new Lazy<Server>(() => new Server());

        public static Server Instance
        {
            get { return _instance.Value; }
        }

        #endregion

        public List<TcpClient> clients;
        public void SendMessage(string message)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(SendThread));
            thread.Start(message);
        }
        private Server()
        {
            clients = new List<TcpClient>();
            Thread listern = new Thread(new ParameterizedThreadStart(ListernerThread));
            listern.Start(9050);
        }
        static void ListernerThread(Object Port)
        {
            TcpListener Listener;
            Listener = new TcpListener(IPAddress.Any, (int)Port);
            Listener.Start();
            string map = MyMap.GetStringMap();
            byte[] buffer = Encoding.ASCII.GetBytes(map);
            while (true)
            {
                TcpClient Client = Listener.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(ClientThread));
                clientThread.Start(Client);
            }
        }

        static void ClientThread(Object client)
        {
            var Client = (TcpClient)client;
            Encoding enc = Encoding.GetEncoding("us-ascii");
            string map = MyMap.GetStringMap();
            byte[] buffer = Encoding.ASCII.GetBytes(map);
            while (true)
            {
                var recieve = new byte[1000];
                try
                {
                    Client.GetStream().Read(recieve, 0, 1000);
                }
                catch
                {
                    Client.Close();
                    break;
                }
                var str = enc.GetString(recieve);
                str = str.Trim('\0');
                if (str == "200")
                {
                    try
                    {
                        Client.GetStream().Write(buffer, 0, buffer.Length);
                    }
                    catch
                    {
                        Client.Close();
                        break;
                    }
                }
                else if(str == "201")
                    lock (Server.Instance.clients)
                    {
                        Server.Instance.clients.Add(Client);
                    }
            }
        }

        static void SendThread(Object Msg)
        {
            string message = Msg.ToString();
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            lock (Server.Instance.clients)
            {
                for(var i = 0; i < Instance.clients.Count; i++)
                {
                    try
                    {
                        Instance.clients[i].GetStream().Write(buffer, 0, buffer.Length);
                    }
                    catch
                    {
                        Instance.clients[i].Close();
                        Instance.clients.Remove(Instance.clients[i]);
                    }
                }
                
            }
        }


        

        
    }

}