using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMessageQueue.SAL
{
    public class QueueConnectionFactory : IQueueConnectionFactory
    {
        public IConnection GetConnection(string hostname)
        {
            var factory = new ConnectionFactory() { HostName = hostname };
            return factory.CreateConnection();
        }
    }
}
