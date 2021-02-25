using MyMessageQueue.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.DAL
{
    public class MessageQueueDataManager : IMessageQueueDataManager
    {
        private MyMessageQueueDBContext _dbContext;
        public MessageQueueDataManager(MyMessageQueueDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(QueueMessage queueMessage)
        {
            await _dbContext.AddAsync<QueueMessage>(queueMessage);
            await _dbContext.SaveChangesAsync();
        } 
    }
}
