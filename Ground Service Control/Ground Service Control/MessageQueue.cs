using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Events;

namespace Ground_Service_Control
{
    public class MessageQueue
    {
        public MessageQueue()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "tester";
            factory.Password = "tester";
            factory.VirtualHost = "/";
            factory.HostName = "airport-dko-1.cloudapp.net";
            factory.Port = 5672;

            IConnection connection = factory.CreateConnection();
            m_channel = connection.CreateModel();

            m_channel.QueueDeclare(m_queueName, false, false, false, null);
        }

        public void queueMessage(string message, DateTime date)
        {
            message = date.ToString() + ": " + message;

            var body = Encoding.UTF8.GetBytes(message);

            m_channel.BasicPublish("", m_queueName, null, body);
        }

        private string m_queueName = "GSC";
        private readonly IModel m_channel = null;
    }
}