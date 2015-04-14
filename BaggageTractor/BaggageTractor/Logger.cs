using System;
using System.Text;
using BaggageTractor.MetrologServiceVS;
using RabbitMQ.Client;

namespace BaggageTractor
{
    public static class Logger
    {
        private static readonly string QueueName;
        private static readonly IModel Channel;

        static Logger()
        {
            var factory = new ConnectionFactory
            {
                UserName = "tester",
                Password = "tester",
                VirtualHost = "/",
                HostName = "airport-dko-1.cloudapp.net",
                Port = 5672
            };

            Channel = factory.CreateConnection().CreateModel();

            QueueName = "LoggerQueue";

            //декларируем имя очереди
            Channel.QueueDeclare(QueueName, false, false, false, null);
        }

        public static void SendMessage(int level, string componentName, string message)
        {
            DateTime dt = new MetrologService().GetCurrentTime(); //узнаем время у метрологической службы

            /*Кладем сообщения строго в очередь LoggerQueue сторого в указанном ниже формате:
            07.04.2015_23:28:22_1_TestMQ_Hello World!*/
            string logMessage = String.Format("{0}_{1}_{2}_{3}_{4}",
                dt.ToString("dd.MM.yyyy"),
                dt.ToString("HH:mm:ss"),
                level,
                componentName,
                message);

            //передача сообщения в очередь
            var body = Encoding.UTF8.GetBytes(logMessage); // декодируем в UTF8
            Channel.BasicPublish("", QueueName, null, body);
        }
    }
}