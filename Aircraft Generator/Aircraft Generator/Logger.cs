﻿using System;
using System.Diagnostics;
using System.Text;
using RabbitMQ.Client;

namespace Aircraft_Generator
{
    public static class Logger
    {
        private static  string QueueName;
        private static  IModel Channel;

        private static object _lockObject = new object();

        static Logger()
        {

        }

        public static void SendMessage(int level, string componentName, string message)
        {
            try
            {

            lock (_lockObject)
            {
                var metrolog = new MetrologicalService.MetrologService();
                var factory = new ConnectionFactory
                {
                    UserName = "tester",
                    Password = "tester",
                    VirtualHost = "/",
                    HostName = "airport-dko-1.cloudapp.net",
                    AutomaticRecoveryEnabled = true,
                    Port = 5672
                };

                var connection = factory.CreateConnection();
                Channel = connection.CreateModel();

                QueueName = "LoggerQueue";

                //декларируем имя очереди
                Channel.QueueDeclare(QueueName, false, false, false, null);

                DateTime dt = metrolog.GetCurrentTime(); //узнаем время у метрологической службы

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
            catch (Exception exception)
            {
                Debug.WriteLine(String.Format("Error in Logger: {0}", exception.Message));
            }
        }
    }
}