using System;
using RabbitMQ.Client;
using System.Text;
using System.Net.Http;
using MyMessageQueue.Model;
using System.Threading.Tasks;
using ConsoleAppBase;
using Newtonsoft.Json;

namespace Send
{
    public class Program : ConsoleBase
    {
        static HttpClient client = new HttpClient();

        public Program() : base("appsettings.json")
        {
            client.BaseAddress = new Uri(_configuration["baseAdress"]);
        }
        static void Main(string[] args)
        {
            var program = new Program();
            program.MainAsync().GetAwaiter().GetResult();

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        public async Task MainAsync()
        {
            while (true)
            {
                var queueMessage = new QueueMessage()
                {
                    MessageTimestamp = DateTime.UtcNow
                };

                await client.PostAsync("MessageQueue/AddToQueue", new StringContent(JsonConvert.SerializeObject(queueMessage), Encoding.UTF8, "application/json"));
                await Task.Delay(500);
            }
            
        }
    }
}
