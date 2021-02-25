using MyMessageQueue.Model;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.BLL
{
    public interface IMessageQueueLogic
    {
        Task AddToQueueAsync(QueueMessage queueMessage);

        Task ProcessQueueElementAsync(QueueMessageDTO ea);

    }
}
