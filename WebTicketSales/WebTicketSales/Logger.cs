using System;
using System.Text;
using RabbitMQ.Client;

namespace WebTicketSales
{
    public static class Logger
    {
        private static string QueueName;
        private static IModel Channel;

        private static readonly object _lockObject = new object();

        static Logger()
        {
        }

        public static void SendMessage(string message)
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

                IConnection connection = factory.CreateConnection();
                Channel = connection.CreateModel();

                QueueName = "LoggerQueue";

                //декларируем имя очереди
                Channel.QueueDeclare(QueueName, false, false, false, null);

                MetrologService.MetrologService metrolog = new MetrologService.MetrologService();


                DateTime dt = metrolog.GetCurrentTime(); //узнаем время у метрологической службы

                /*Кладем сообщения строго в очередь LoggerQueue сторого в указанном ниже формате:
            07.04.2015_23:28:22_1_TestMQ_Hello World!*/
                string logMessage = String.Format("{0}_{1}_{2}_{3}_{4}",
                    dt.ToString("dd.MM.yyyy"),
                    dt.ToString("HH:mm:ss"),
                    0,
                    "Ticket Sales",
                    message);

                //передача сообщения в очередь
                byte[] body = Encoding.UTF8.GetBytes(logMessage); // декодируем в UTF8
                Channel.BasicPublish("", QueueName, null, body);
                Channel.Close();
                connection.Close();
            }
        }
    }
}