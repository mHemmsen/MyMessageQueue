using MyMessageQueue.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.DAL
{
    public interface IErrorLogDataManager
    {
        Task AddErrorLogAsync(LogMessage logMessage);
    }
}
