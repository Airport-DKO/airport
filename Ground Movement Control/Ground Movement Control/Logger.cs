using System;
using System.Text;
using RabbitMQ.Client;

namespace Ground_Movement_Control
{
    public static class Logger
    {
        private static string QueueName;
        private static IModel Channel;

        private static readonly object _lockObject = new object();

        static Logger()
        {
        }

        public static void SendMessage(int level, string componentName, string message, DateTime dateTime)
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

                DateTime dt = dateTime; //узнаем время у метрологической службы

                /*Кладем сообщения строго в очередь LoggerQueue сторого в указанном ниже формате:
            07.04.2015_23:28:22_1_TestMQ_Hello World!*/
                string logMessage = String.Format("{0}_{1}_{2}_{3}_{4}",
                    dt.ToString("dd.MM.yyyy"),
                    dt.ToString("HH:mm:ss"),
                    level,
                    componentName,
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