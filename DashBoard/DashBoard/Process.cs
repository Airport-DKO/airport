﻿using System;
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
    class Process
    {
        ManualResetEvent m_EventStop;
        ManualResetEvent m_EventStopped;
        DashBoard.Form1 m_form;

        public Process(ManualResetEvent eventStop,
                           ManualResetEvent eventStopped,
                           DashBoard.Form1 form)
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

                    while (true)
                    {
                        BasicDeliverEventArgs ea;
                        ConnectionFactory factory = new ConnectionFactory();
                        factory.UserName = "tester";
                        factory.Password = "tester";
                        factory.VirtualHost = "/";
                        factory.HostName = "airport-dko-1.cloudapp.net";
                        factory.Port = 5672;

                        IConnection connection = factory.CreateConnection();
                        IModel channel = connection.CreateModel();

                        channel.QueueDeclare("StatusQueue", false, false, false, null);

                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume("StatusQueue", true, consumer);

                        if (consumer.Queue.Dequeue(20000, out ea))
                        {
                            var body_read = ea.Body;
                            var message_read = Encoding.UTF8.GetString(body_read);
                            Thread.Sleep(1);


                            m_form.Invoke(m_form.m_DelegateAddString, new Object[] { message_read });

                            channel.Close();
                            connection.Close();

                        }

                        if (m_EventStop.WaitOne(0, true))
                        {
                            m_EventStopped.Set();
                            return;
                        }
                    }
                    m_form.Invoke(m_form.m_DelegateThreadFinished, null);
                }
                catch
                {

                }
            }

        }
    }
}
