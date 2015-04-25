using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.Logic
{
    public class Server
    {
        #region Singleton_realization

        private static readonly Lazy<Server> _instance =
            new Lazy<Server>(() => new Server());

        public static Server Instance { get { return _instance.Value; } }

        #endregion

        public List<TcpClient> Clients;
        public void SendMessage(string message)
        {
            new Task(()=>SendThread(message)).Start();
        }
        private Server()
        {
            Clients = new List<TcpClient>();
            new Thread(ListernerThread).Start(9050);
            new Thread(SupportThread).Start();
        }

        static void SupportThread()
        {
            while (true)
            {
                Instance.SendMessage("1.");
                Thread.Sleep(10000);
            }
        }

        static void ListernerThread(object port)
        {
            if (port == null) return;
            var listener = new TcpListener(IPAddress.Any, (int)port);
            listener.Start();
            while (true)
            {
                var client = listener.AcceptTcpClient();
                new Thread(ClientThread).Start(client);
            }
        }

        static void ClientThread(object client)
        {
            if (client == null) return;
            var Client = (TcpClient)client;
            var enc = Encoding.GetEncoding("us-ascii");

            #region Удалить перед релизом
            Data.Data.Instance.RefreshMapString();
            #endregion

            var buffer = Encoding.ASCII.GetBytes(Data.Data.Instance.MapString);
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
                var str = enc.GetString(recieve).Trim('\0');
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
                    lock (Instance.Clients)
                    {
                        Instance.Clients.Add(Client);
                    }
            }
        }

        static void SendThread(object msg)
        {
            var buffer = Encoding.ASCII.GetBytes(msg.ToString());

            lock (Instance.Clients)
            {
                for(var i = 0; i < Instance.Clients.Count; i++)
                {
                    try
                    {
                        Instance.Clients[i].GetStream().Write(buffer, 0, buffer.Length);
                    }
                    catch
                    {
                        Instance.Clients[i].Close();
                        Instance.Clients.Remove(Instance.Clients[i]);
                    }
                }
                
            }
        }

    }
}