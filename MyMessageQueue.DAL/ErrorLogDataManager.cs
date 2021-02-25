using MyMessageQueue.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.DAL
{
    public class ErrorLogDataManager : IErrorLogDataManager
    {
        private MyMessageQueueDBContext _dbContext;
        public ErrorLogDataManager(MyMessageQueueDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddErrorLogAsync(LogMessage logMessage)
        {
            await _dbContext.AddAsync<LogMessage>(logMessage);
            await _dbContext.SaveChangesAsync();
        }
    }
}
