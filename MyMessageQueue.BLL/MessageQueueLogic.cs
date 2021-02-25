using MyMessageQueue.DAL;
using MyMessageQueue.Model;
using MyMessageQueue.SAL;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMessageQueue.BLL
{
    public class MessageQueueLogic : IMessageQueueLogic
    {
        private IMessageQueueServiceManager _messageQueueServiceManager;
        private IMessageQueueDataManager _messageQueueDataManager;

        public MessageQueueLogic(IMessageQueueServiceManager messageQueueServiceManager, IMessageQueueDataManager messageQueueDataManager)
        {
            _messageQueueServiceManager = messageQueueServiceManager;
            _messageQueueDataManager = messageQueueDataManager;
        }
        public async Task AddToQueueAsync(QueueMessage queueMessage)
        {
            await _messageQueueServiceManager.AddToQueueAsync(queueMessage);
        }


        public async Task ProcessQueueElementAsync(QueueMessageDTO ea)
        {
            var queueMessage = ea.QueueMessage;
            try
            {
                if (DateTime.UtcNow - queueMessage.MessageTimestamp < new TimeSpan(0, 0, 60))
                {
                    if (IsEven(queueMessage.MessageTimestamp.Second))
                    {
                        //Save to database
                        await _messageQueueDataManager.CreateAsync(queueMessage);
                        _messageQueueServiceManager.Ackknowledge(ea.DeliveryTag, false);
                    }
                    else
                    {
                        //Requeue with new timestamp
                        await RequeueAsync(queueMessage);
                    }
                }
            }
            catch (Exception e)
            {
                await ErrorRequeueAsync(queueMessage);
                throw e;
            }
        }

        private async Task RequeueAsync(QueueMessage queueMessage)
        {
            queueMessage.MessageTimestamp = DateTime.UtcNow;
            queueMessage.RequedCount++;
            await AddToQueueAsync(queueMessage);
        }

        private async Task ErrorRequeueAsync(QueueMessage queueMessage)
        {
            queueMessage.ErrorRequeuedCount++;
            await AddToQueueAsync(queueMessage);
        }

        private bool IsEven(int seconds)
        {
            return seconds % 2 == 0;
        }
    }
}
