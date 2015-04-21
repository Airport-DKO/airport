using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Aircraft_Generator.MetrologicalService;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Aircraft_Generator
{
    public class Rabbit
    {
        #region Singleton_realization

        private static readonly Lazy<Rabbit> _instance =
            new Lazy<Rabbit>(() => new Rabbit());

        public static Rabbit Instance
        {
            get { return _instance.Value; }
        }

        #endregion

        private QueueingBasicConsumer _consumer;

        private Rabbit()
        {
            var m = new MetrologService();

            CurrentCoef = m.GetCurrentTick();
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

            channel.QueueDeclare("TC_AircraftGenerator", true, false, false, null);

            _consumer = new QueueingBasicConsumer(channel);
            channel.BasicConsume("TC_AircraftGenerator", true, _consumer);
            var listenTask = new Task(ListenQueue);
            listenTask.Start();
        }

        public double CurrentCoef { get; private set; }
        public event EventHandler<MetrologicalEventArgs> MessageReceived;

        private void ListenQueue()
        {
            try
            {
                while (true)
                {
                    BasicDeliverEventArgs ea = _consumer.Queue.Dequeue();
                    byte[] body = ea.Body;
                    string message = Encoding.UTF8.GetString(body);
                    float newCoef = float.Parse(message, CultureInfo.InvariantCulture);
                    if (newCoef != CurrentCoef)
                    {
                        if (MessageReceived != null)
                        {
                            MessageReceived(this, new MetrologicalEventArgs {NewCoef = newCoef});
                        }
                        CurrentCoef = newCoef;
                        Logger.SendMessage(0, "AircraftGenerator", String.Format("Получили новый коэффициент скорости {0}", newCoef),
                    DateTime.MinValue);
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Exception {0} in Rabbit class",exception.Message);
                var m = new MetrologService();

                CurrentCoef = m.GetCurrentTick();
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

                channel.QueueDeclare("TC_AircraftGenerator", true, false, false, null);

                _consumer = new QueueingBasicConsumer(channel);
                channel.BasicConsume("TC_AircraftGenerator", true, _consumer);
                var listenTask = new Task(ListenQueue);
                listenTask.Start();
            }
        }
    }

    public class MetrologicalEventArgs : EventArgs
    {
        public float NewCoef { get; set; }
    }
}