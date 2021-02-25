using ConsoleAppBase;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyMessageQueue.Model;

namespace Receive
{
    public class Program : ConsoleBase
    {
        private static HttpClient _client = new HttpClient();
        private IModel _channel;
        private string _queueName;
        static void Main(string[] args)
        {
            var program = new Program();
            program.RunAsync().GetAwaiter().GetResult();
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
        public Program() : base("appsettings.json")
        {
            _client.BaseAddress = new Uri(_configuration["baseAdress"]);
            _queueName = "MyMessageQueue";
            _channel = base.CreateRabbitMqChannel(_queueName, _configuration["rabbitMQHost"]);
        }

        public async Task RunAsync()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                await ProcressQueueMesasge(ea);
            };
            _channel.BasicConsume(queue: _queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public async Task ProcressQueueMesasge(BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] Received {0}", message);

            var queueMsgDTO = new QueueMessageDTO()
            {
                QueueMessage = JsonConvert.DeserializeObject<QueueMessage>(message),
                DeliveryTag = ea.DeliveryTag
            };

            var content = new StringContent(JsonConvert.SerializeObject(queueMsgDTO), Encoding.UTF8, "application/json");
            await _client.PostAsync("MessageQueue/ProcessQueueElement", content);
        }
    }
}

    

