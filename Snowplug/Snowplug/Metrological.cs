using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Snowplug
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

        private QueueingBasicConsumer _consumer;

        public event EventHandler<MetrologicalEventArgs> MessageReceived;
        public double CurrentCoef { get; private set; }

        private Metrological()
        {
            CurrentCoef = new MetrologService.MetrologService().GetCurrentTick();
           
            var listenTask = new Task(ListenQueue);
            listenTask.Start();
        }

        private void ListenQueue()
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

                    channel.QueueDeclare("TC_SnowremovalVehicle", true, false, false, null);

                    _consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("TC_SnowremovalVehicle", true, _consumer);
                    while(true)
                    {
                        if (_consumer.Queue.Dequeue(999999999, out ea))
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            var newCoef = float.Parse(message, CultureInfo.InvariantCulture);
                            if (newCoef != CurrentCoef)
                            {
                                if (MessageReceived != null)
                                {
                                    MessageReceived(this, new MetrologicalEventArgs() {NewCoef = newCoef});
                                }
                                CurrentCoef = newCoef;

                            }
                        }
                    }
                    channel.Close();
                    connection.Close();
                }
                catch
                {}
            }
        }
    }

    public class MetrologicalEventArgs : EventArgs
    {
        public float NewCoef { get; set; }
    }
}