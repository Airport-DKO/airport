using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using RabbitMQ.Client;

namespace WebCheckIn
{
    public class MqSender
    {
        private IModel channel;
        private string MQName;

        public MqSender(string mqName)
        {
            MQName = mqName;
        }

        public bool Connect()
        {
            try
            {
                ConnectionFactory factory = new ConnectionFactory();
                factory.UserName = "tester";
                factory.Password = "tester";
                factory.VirtualHost = "/";
                factory.HostName = "airport-dko-1.cloudapp.net";
                factory.Port = 5672;

                IConnection connection = factory.CreateConnection();
                channel = connection.CreateModel();

                // Декларируем имя очереди
                channel.QueueDeclare(MQName, false, false, false, null);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public void SendMsg(string msg)
        {
            try
            {
                var body = Encoding.UTF8.GetBytes(msg); // декодируем в UTF8, хз можно ли без этого
                channel.BasicPublish("", MQName, null, body);
            }
            catch (Exception ex)
            {
                //if (Connect())
                //    SendMsg(msg);
            }
        }
    }
}