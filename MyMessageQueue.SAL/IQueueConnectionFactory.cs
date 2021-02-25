using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMessageQueue.SAL
{
    public interface IQueueConnectionFactory
    {
        IConnection GetConnection(string hostname);
    }
}
