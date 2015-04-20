﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using WebApplicationWeather.MetrologServiceVS;
using RabbitMQ.Client;
 
namespace WebApplicationWeather
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
            //DateTime dt = new MetrologService().GetCurrentTime();
 
            //string logMessage = String.Format("{0}_{1}_{2}_{3}_{4}",
            //    dt.ToString("dd.MM.yyyy"),
            //    dt.ToString("HH:mm:ss"),
            //    level,
            //    componentName,
            //    message);
 
            //var body = Encoding.UTF8.GetBytes(logMessage);
            //Channel.BasicPublish("", QueueName, null, body);
        }
    }
}