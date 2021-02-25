using System;
using System.Collections.Generic;
using System.Text;

namespace MyMessageQueue.Model
{
    public enum ProcressElementResponse
    {
        Requeue = 0,
        Ackknowledge = 10,
        CreatedInDatabase = 20
    }
}
