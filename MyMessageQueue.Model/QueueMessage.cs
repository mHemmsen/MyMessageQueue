using System;
using System.Collections.Generic;
using System.Text;

namespace MyMessageQueue.Model
{
    public class QueueMessage
    {
        public int QueueMessageId { get; set; }
        public DateTime MessageTimestamp { get; set; }
        public int RequedCount { get; set; }
        public int ErrorRequeuedCount { get; set; }
    }
}
