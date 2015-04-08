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

namespace Logger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            m_DelegateAddString = new DelegateAddString(this.AddString);
            m_DelegateThreadFinished = new DelegateThreadFinished(this.ThreadFinished);

            m_EventStopThread = new ManualResetEvent(false);
            m_EventThreadStopped = new ManualResetEvent(false);
        }

        public delegate void DelegateAddString(String s);
        public delegate void DelegateThreadFinished();

        Thread m_WorkerThread;

        ManualResetEvent m_EventStopThread;
        ManualResetEvent m_EventThreadStopped;

        public DelegateAddString m_DelegateAddString;
        public DelegateThreadFinished m_DelegateThreadFinished;


        private void btnStartThread_Click(object sender, System.EventArgs e)
        {
            btnStartThread.Enabled = false;
            btnStopThread.Enabled = true;

            m_EventStopThread.Reset();
            m_EventThreadStopped.Reset();

            m_WorkerThread = new Thread(new ThreadStart(this.WorkerThreadFunction));

            m_WorkerThread.Name = "Logger Thread";

            m_WorkerThread.Start();

        }

        private void btnStopThread_Click(object sender, System.EventArgs e)
        {
            StopThread();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
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

            channel.QueueDeclare("LoggerQueue", false, false, false, null);

            string message = "-1";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", "LoggerQueue", null, body);

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

            ThreadFinished();
        }

        private void AddString(String s)
        {
            if (s != "-1")
            {
                String[] words = s.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                logGridView.Rows.Add(words[0], words[1], words[2], words[3], words[4]);
            }
        }

        private void ThreadFinished()
        {
            btnStartThread.Enabled = true;
            btnStopThread.Enabled = false;
        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            logGridView.Rows.Clear();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopThread();
        }
    }
}
