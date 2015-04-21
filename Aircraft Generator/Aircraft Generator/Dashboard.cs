using System;
using System.Text;
using RabbitMQ.Client;

namespace Aircraft_Generator
{
    public static class Dashboard
    {
        private static string QueueName;
        private static IModel Channel;

        private static readonly object _lockObject = new object();

        static Dashboard()
        {
        }

        public static void SendMessage(int y, int z)
        {
            lock (_lockObject)
            {
                var factory = new ConnectionFactory
                {
                    UserName = "tester",
                    Password = "tester",
                    VirtualHost = "/",
                    HostName = "airport-dko-1.cloudapp.net",
                    AutomaticRecoveryEnabled = true,
                    Port = 5672
                };

                Channel = factory.CreateConnection().CreateModel();

                QueueName = "StatusQueue";

                //декларируем имя очереди
                Channel.QueueDeclare(QueueName, false, false, false, null);


                /*Кладем сообщения строго в очередь LoggerQueue сторого в указанном ниже формате:
            07.04.2015_23:28:22_1_TestMQ_Hello World!*/
                string logMessage = String.Format("PL_{0}_{1}", y.ToString(), z.ToString());

                //передача сообщения в очередь
                byte[] body = Encoding.UTF8.GetBytes(logMessage); // декодируем в UTF8
                Channel.BasicPublish("", QueueName, null, body);
            }
        }
    }
}