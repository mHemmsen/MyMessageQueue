using MyMessageQueue.DAL;
using MyMessageQueue.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.BLL
{
    public class ErrorLogLogic : IErrorLogLogic
    {
        private IErrorLogDataManager _errorLogDataManager;
        public ErrorLogLogic(IErrorLogDataManager errorLogDataManager)
        {
            _errorLogDataManager = errorLogDataManager;
        }
        public async Task AddLogMessageAsync(LogMessage logMessage)
        {
            await _errorLogDataManager.AddErrorLogAsync(logMessage);
        }
    }
}
