using MyMessageQueue.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.SAL
{
    public interface IQueueServiceManagerBase
    {
        Task AddToQueueAsync(QueueMessage message);
        void Ackknowledge(ulong deleveryTag, bool multiple);
    }
}
