using MyMessageQueue.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.DAL
{
    public interface IMessageQueueDataManager
    {
        Task CreateAsync(QueueMessage queueMessage);
    }
}
