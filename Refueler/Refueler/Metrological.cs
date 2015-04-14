﻿using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Refueler
{
    public class Metrological
    {
        #region Singleton_realization

        private static readonly Lazy<Metrological> _instance = new Lazy<Metrological>(() => new Metrological());

        public static Metrological Instance
        {
            get { return _instance.Value; }
        }

        #endregion

        private readonly QueueingBasicConsumer _consumer;

        public event EventHandler<MetrologicalEventArgs> MessageReceived;
        public float CurrentCoef { get; private set; }

        private Metrological()
        {
            CurrentCoef = 1;
            var factory = new ConnectionFactory
            {
                UserName = "tester",
                Password = "tester",
                VirtualHost = "/",
                HostName = "airport-dko-1.cloudapp.net",
                Port = 5672
            };

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueueDeclare("TC_Refueler", true, false, false, null);

            _consumer = new QueueingBasicConsumer(channel);
            channel.BasicConsume("TC_Refueler", true, _consumer);
            var listenTask = new Task(ListenQueue);
            listenTask.Start();
        }

        private void ListenQueue()
        {
            while (true)
            {
                var ea = _consumer.Queue.Dequeue();
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                var newCoef = float.Parse(message, CultureInfo.InvariantCulture);
                if (newCoef != CurrentCoef)
                {
                    MessageReceived(this, new MetrologicalEventArgs() { NewCoef = newCoef });
                    CurrentCoef = newCoef;
                }
            }
        }
    }

    public class MetrologicalEventArgs : EventArgs
    {
        public float NewCoef { get; set; }
    }
}
