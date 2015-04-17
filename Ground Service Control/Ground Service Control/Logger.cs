using System;
using System.Text;
using RabbitMQ.Client;

namespace Ground_Service_Control 
{
    public static class Logger
    {
        public static void SendMessage(string message)
        {
            var factory = new ConnectionFactory
            {
                UserName = "tester",
                Password = "tester",
                VirtualHost = "/",
                HostName = "airport-dko-1.cloudapp.net",
                Port = 5672
            };

            IModel Channel = factory.CreateConnection().CreateModel();

            string QueueName = "LoggerQueue";

            Channel.QueueDeclare(QueueName, false, false, false, null);

            DateTime dt = new MetrologService.MetrologService().GetCurrentTime();

            /*Кладем сообщения строго в очередь LoggerQueue сторого в указанном ниже формате:
            07.04.2015_23:28:22_1_TestMQ_Hello World!*/
            string logMessage = String.Format("{0}_{1}_{2}_{3}_{4}",
                dt.ToString("dd.MM.yyyy"),
                dt.ToString("HH:mm:ss"),
                0,
                "HandlingSupervisor",
                message);

            var body = Encoding.UTF8.GetBytes(logMessage);
            Channel.BasicPublish("", QueueName, null, body);
        }
    }
}