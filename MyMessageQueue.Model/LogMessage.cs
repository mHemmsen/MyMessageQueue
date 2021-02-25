using System;
using System.Collections.Generic;
using System.Text;

namespace MyMessageQueue.Model
{
    public class LogMessage
    {
        public int LogMessageId { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
    