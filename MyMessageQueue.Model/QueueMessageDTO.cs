using System;
using System.Collections.Generic;
using System.Text;

namespace MyMessageQueue.Model
{
    public class QueueMessageDTO
    {
        public QueueMessage QueueMessage { get; set; }
        public ulong DeliveryTag { get; set; }
    }
}
