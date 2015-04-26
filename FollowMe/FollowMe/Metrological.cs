using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using FollowMe.MetrologServiceVS;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FollowMe
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
            CurrentCoef = new MetrologService().GetCurrentTick();

            var listenTask = new Task(ListenQueue);
            listenTask.Start();
        }

        private void ListenQueue()
        {
            while (true)
            {
                IConnection connection;
                IModel channel;
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

                    connection = factory.CreateConnection();
                    channel = connection.CreateModel();

                    channel.QueueDeclare("TC_FollowmeVan", true, false, false, null);

                    _consumer = new QueueingBasicConsumer(channel);

                    while (true)
                    {
                        channel.BasicConsume("TC_FollowmeVan", true, _consumer);
                        if (_consumer.Queue.Dequeue(30000, out ea))
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

                                Logger.SendMessage(3, Worker.ComponentName,
                                    "Новый коэффициент скорости " + newCoef.ToString());
                            }
                        }
                        else
                        {
                            Logger.SendMessage(3, Worker.ComponentName,
                                "Новый коэффициент скорости не приходил в таймаут");
                        }
                    }

                }
                catch (Exception)
                {

                }

            }
        }
    }

    public class MetrologicalEventArgs : EventArgs
    {
        public double NewCoef { get; set; }
    }
}