using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration.Json;
using RabbitMQ.Client;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http;

namespace ConsoleAppBase
{
    public class ConsoleBase
    {
        protected IConfiguration _configuration;

        public ConsoleBase(string appsettingsFileName)
        {
            _configuration = new ConfigurationBuilder().AddJsonFile(appsettingsFileName, true, true).Build();
        }

        public IModel CreateRabbitMqChannel(string queueName, string hostName, bool durable = false, bool exclusive = false, bool autoDelete = false, Dictionary<string, object> arguments = null)
        {
            var factory = new ConnectionFactory() { HostName = hostName };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName,
                                    durable: durable,
                                    exclusive: exclusive,
                                    autoDelete: autoDelete,
                                    arguments: arguments);

            return channel;
        }
    }
}
