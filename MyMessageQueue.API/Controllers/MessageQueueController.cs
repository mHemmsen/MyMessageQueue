using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMessageQueue.Model;
using MyMessageQueue.BLL;
using RabbitMQ.Client.Events;

namespace MyMessageQueue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageQueueController : ControllerBase
    {
        private IMessageQueueLogic _messageQueueLogic;
       
        public MessageQueueController(IMessageQueueLogic messageQueueLogic)
        {
            _messageQueueLogic = messageQueueLogic;
        }

        [HttpPost]
        [Route(nameof(AddToQueue))]
        public async Task AddToQueue([FromBody]QueueMessage queueMessage)
        {
            await _messageQueueLogic.AddToQueueAsync(queueMessage);
        }

        [HttpPost]
        [Route(nameof(ProcessQueueElement))]
        public async Task ProcessQueueElement([FromBody]QueueMessageDTO ea)
        {
            await _messageQueueLogic.ProcessQueueElementAsync(ea);
        }
    }
}
