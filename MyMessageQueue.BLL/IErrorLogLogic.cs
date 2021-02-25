using MyMessageQueue.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.BLL
{
    public interface IErrorLogLogic
    {
        Task AddLogMessageAsync(LogMessage logMessage);
    }
}
