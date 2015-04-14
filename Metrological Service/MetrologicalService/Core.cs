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

        public Timer modTimer = new System.Timers.Timer(200);
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
            timer = timer.AddSeconds(1/ModelingSpeed / 5);
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

            channel.ExchangeDeclare("MetrologQueue", "topic", true);

            string message = num.ToString();
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("MetrologQueue", "", null, body);

            channel.Close();
            connection.Close();
        }

        public void ClearAllQueues()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "tester";
            factory.Password = "tester";
            factory.VirtualHost = "/";
            factory.HostName = "airport-dko-1.cloudapp.net";
            factory.Port = 5672;

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueuePurge("TC_AircraftGenerator");
            channel.QueuePurge("TC_BaggageTractor");
            channel.QueuePurge("TC_CateringTruck");
            channel.QueuePurge("TC_Checkin");
            channel.QueuePurge("TC_ContainerLoader");
            channel.QueuePurge("TC_Deicer");
            channel.QueuePurge("TC_FollowmeVan");
            channel.QueuePurge("TC_GroundMovementControl");
            channel.QueuePurge("TC_HandlingSupervisor");
            channel.QueuePurge("TC_InformationPanel");
            channel.QueuePurge("TC_Logger");
            channel.QueuePurge("TC_PassengerBus");
            channel.QueuePurge("TC_PassengerStairs");
            channel.QueuePurge("TC_PassengersGenerator");
            channel.QueuePurge("TC_Refueler");
            channel.QueuePurge("TC_SnowremovalVehicle");
            channel.QueuePurge("TC_SystemDashboard");
            channel.QueuePurge("TC_TicketSales");
            channel.QueuePurge("TC_Time");
            channel.QueuePurge("TC_TowerControl");
            channel.QueuePurge("TC_VIPShuttle");
            channel.QueuePurge("TC_Visualization");
            channel.QueuePurge("TC_Weather");

            channel.Close();
            connection.Close();
        }
    }
}