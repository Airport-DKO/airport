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

namespace Logger
{
    class Process
    {
        ManualResetEvent m_EventStop;
        ManualResetEvent m_EventStopped;
        FormMain m_form;

        public Process(ManualResetEvent eventStop,
                           ManualResetEvent eventStopped,
                           FormMain form)
        {
            m_EventStop = eventStop;
            m_EventStopped = eventStopped;
            m_form = form;
        }


        public void Run()
        {
            while (true)
            {
                try
                {
                    BasicDeliverEventArgs ea;
                    var factory = new ConnectionFactory
                    {
                        UserName = "tester",
                        Password = "tester",
                        VirtualHost = "/",
                        HostName = "airport-dko-1.cloudapp.net",
                        AutomaticRecoveryEnabled = true,
                        Port = 5672
                    };

                    IConnection connection = factory.CreateConnection();
                    IModel channel = connection.CreateModel();

                    channel.QueueDeclare("LoggerQueue", false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("LoggerQueue", true, consumer);

                    while (true)
                    {
                        if (consumer.Queue.Dequeue(999999999, out ea))
                        {
                            var body_read = ea.Body;
                            var message_read = Encoding.UTF8.GetString(body_read);
                            Thread.Sleep(1);


                            m_form.Invoke(m_form.m_DelegateAddString, new Object[] { message_read });
                        }

                        if (m_EventStop.WaitOne(0, true))
                        {
                            channel.Close();
                            connection.Close();
                            m_EventStopped.Set();

                            return;
                        }
                    }
                    m_form.Invoke(m_form.m_DelegateThreadFinished, null);
                    channel.Close();
                    connection.Close();
                }
                catch
                {

                }
            }
        }
    }
}
