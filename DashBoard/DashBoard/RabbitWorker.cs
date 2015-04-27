using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Events;

namespace DashBoard
{
    class RabbitWorker
    {
        ManualResetEvent m_EventStop2;
        ManualResetEvent m_EventStopped2;
        DashBoard.Form1 m_form;

        public RabbitWorker(ManualResetEvent eventStop,
                           ManualResetEvent eventStopped,
                           DashBoard.Form1 form)
        {
            m_EventStop2 = eventStop;
            m_EventStopped2 = eventStopped;
            m_form = form;
        }

        public void Run()
        {
            while (true)
            {
                try
                {

                    while (true)
                    {
                        Thread.Sleep(5000);
                        ConnectionFactory factory = new ConnectionFactory();
                        factory.UserName = "tester";
                        factory.Password = "tester";
                        factory.VirtualHost = "/";
                        factory.HostName = "airport-dko-1.cloudapp.net";
                        factory.Port = 5672;

                        IConnection connection = factory.CreateConnection();
                        IModel channel = connection.CreateModel();

                        channel.QueueDeclare("StatusQueue", false, false, false, null);

                        string message = "-1";
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish("", "StatusQueue", null, body);

                        channel.Close();
                        connection.Close();

                            if (m_EventStop2.WaitOne(0, true))
                            {
                                m_EventStopped2.Set();
                                return;
                            }
                    }
                }
                catch
                {

                }
            }

        }
    }
}
