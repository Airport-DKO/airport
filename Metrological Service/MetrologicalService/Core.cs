using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Timers;

using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Events;

namespace MetrologicalService
{
    public class Core
    {
        #region Singleton_realization

        private static readonly Lazy<Core> _instance =
            new Lazy<Core>(() => new Core());

        public static Core Instance
        {
            get { return _instance.Value; }
        }

        #endregion

        public Timer modTimer = new System.Timers.Timer(100);
        public DateTime timer = new DateTime();
        public double ModelingSpeed = 1;

        private Core()
        {
            modTimer.Elapsed += timer_Elapsed;
            DateTime now = DateTime.Now;
            modTimer.Start();
            timer = DateTime.Now;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer = timer.AddSeconds(1 * (1/ModelingSpeed) / 10);
        }

        public void Rabb(double num)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "tester";
            factory.Password = "tester";
            factory.VirtualHost = "/";
            factory.HostName = "airport-dko-1.cloudapp.net";
            factory.Port = 5672;

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueueDeclare("MetrologQueue", false, false, false, null);

            string message = num.ToString();
            var body = Encoding.UTF8.GetBytes(message);

            channel.QueuePurge("MetrologQueue");
            channel.BasicPublish("", "MetrologQueue", null, body);

            channel.Close();
            connection.Close();
        }
    }
}