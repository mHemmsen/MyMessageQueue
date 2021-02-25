using MyMessageQueue.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.SAL
{
    public class QueueServiceManagerBase
    {
        protected IModel _queueChannel;
        protected string _queueName;

        public QueueServiceManagerBase(string queueName, IConnection connection, bool durable, bool exclusive, bool autoDelete)
        {
            _queueChannel = connection.CreateModel();
            _queueChannel.QueueDeclare(queue: queueName,
                                     durable: durable,
                                     exclusive: exclusive,
                                     autoDelete: autoDelete,
                                     arguments: null);
        }

        public async Task AddToQueue(QueueMessage message, string exchangeKey = "")
        {
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            _queueChannel.BasicPublish(exchange: exchangeKey, routingKey: _queueName, basicProperties: null, body: messageBody);
        }

        public void Ackknowledge(ulong deleveryTag, bool multiple)
        {
            //_queueChannel.BasicAck(deleveryTag, multiple);
        }
    }
}
