using MyMessageQueue.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.SAL
{
    public class MessageQueueServiceManager : QueueServiceManagerBase, IMessageQueueServiceManager
    {
        public MessageQueueServiceManager(IConnection connection, bool durable = false, bool exclusive = false, bool autoDelete = false) : base("MyMessageQueue", connection, durable, exclusive, autoDelete)
        {
        }

        public async Task AddToQueueAsync(QueueMessage message)
        {
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            _queueChannel.BasicPublish(exchange: "", routingKey: "MyMessageQueue", basicProperties: null, body: messageBody);
        }
    }
}
