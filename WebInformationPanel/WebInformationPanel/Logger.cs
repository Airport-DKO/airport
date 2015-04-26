using System;
using System.Text;
using RabbitMQ.Client;

namespace WebInformationPanel
{
    public static class Logger
    {
        private static readonly object _lockObject = new object();
        public static void SendMessage(int level, string componentName, string message)
        {
            try
            {

                lock (_lockObject)
                {
                    var factory = new ConnectionFactory
                    {
                        UserName = "tester1",
                        Password = "tester1",
                        VirtualHost = "/",
                        HostName = "airport-dko-1.cloudapp.net",
                        AutomaticRecoveryEnabled = true,
                        Port = 5672
                    };
                    var connection = factory.CreateConnection();
                    IModel Channel = connection.CreateModel();

                    string QueueName = "LoggerQueue";

                    //декларируем имя очереди
                    Channel.QueueDeclare(QueueName, false, false, false, null);

                    DateTime dt = new MetrologService.MetrologService().GetCurrentTime(); //узнаем время у метрологической службы

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
                    Channel.Close();
                    connection.Close();
                }

            }
            catch (Exception)
            {
            }
        }
    }
}