using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Events;



namespace DashBoard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            m_DelegateAddString = new DelegateAddString(this.AddString);
           // m_DelegateThreadFinished = new DelegateThreadFinished(this.ThreadFinished);

            m_EventStopThread = new ManualResetEvent(false);
            m_EventThreadStopped = new ManualResetEvent(false);


            m_EventStopThread.Reset();
            m_EventThreadStopped.Reset();

            m_WorkerThread = new Thread(new ThreadStart(this.WorkerThreadFunction));

            m_WorkerThread.Name = "Status Thread";

            m_WorkerThread.Start();
        }


        //
        public delegate void DelegateAddString(String s);
        public delegate void DelegateThreadFinished();

        Thread m_WorkerThread;

        ManualResetEvent m_EventStopThread;
        ManualResetEvent m_EventThreadStopped;

        public DelegateAddString m_DelegateAddString;
        public DelegateThreadFinished m_DelegateThreadFinished;



        //
/*
        public void Run()
        {
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

            while (true)
            {
                var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                var body_read = ea.Body;
                var message_read = Encoding.UTF8.GetString(body_read);
                              
            }       
        }
        */


        private void AddString(String s)
        {
            if (s != "-1")
            {

                String[] words = s.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                // по присланным данным обновляются строки на панели
                switch (words[0])
                {

                    case "PL":
                        switch (words[1])
                        {
                            case "1":
                                {
                                    label21.Text = words[2];
                                }
                                return;
                            case "2":
                                {
                                    label22.Text = words[2];
                                }
                                return;
                            case "3":
                                {
                                    label23.Text = words[2];
                                }
                                return;
                            case "4":
                                {
                                    label24.Text = words[2];
                                }
                                return;
                            case "5":
                                {
                                    label25.Text = words[2];
                                }
                                return;
                            case "6":
                                {
                                    label26.Text = words[2];
                                }
                                return;

                        }
                        return;

                    case "PS":
                        switch (words[1])
                        {
                            case "1":
                                {
                                    label27.Text = words[2];
                                }
                                return;
                            case "2":
                                {
                                    label28.Text = words[2];
                                }
                                return;
                            case "3":
                                {
                                    label29.Text = words[2];
                                }
                                return;
                            case "4":
                                {
                                    label30.Text = words[2];
                                }
                                return;
                            case "5":
                                {
                                    label31.Text = words[2];
                                }
                                return;
                        }
                        return;

                    case "FD":
                        switch (words[1])
                        {
                            case "1":
                                {
                                    label32.Text = words[2];
                                }
                                return;
                            case "2":
                                {
                                    label33.Text = words[2];
                                }
                                return;
                            case "3":
                                {
                                    label34.Text = words[2];
                                }
                                return;
                            case "4":
                                {
                                    label35.Text = words[2];
                                }
                                return;
                            case "5":
                                {
                                    label36.Text = words[2];
                                }
                                return;
                            case "6":
                                {
                                    label37.Text = words[2];
                                }
                                return;

                        }
                        return;
                }
            }
        }

        private void WorkerThreadFunction()
        {
            Process longProcess;

            longProcess = new Process(m_EventStopThread, m_EventThreadStopped, this);

            longProcess.Run();
        }

        private void PutMinusOne()
        {
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
        }

        private void StopThread()
        {

            PutMinusOne();

            if (m_WorkerThread != null && m_WorkerThread.IsAlive)
            {
                m_EventStopThread.Set();

                while (m_WorkerThread.IsAlive)
                {
                    if (WaitHandle.WaitAll(
                        (new ManualResetEvent[] { m_EventThreadStopped }),
                        100,
                        true))
                    {
                        break;
                    }

                    Application.DoEvents();
                }
            }

        
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopThread();
        }


    }
}
