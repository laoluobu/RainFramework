using RainFramework.Mq;
using System.Collections.Concurrent;

namespace RainFramework.EventBus
{
    internal class SimpleMq<M>: ISimpleMq<M>
    {
        private ConcurrentDictionary<string, ConcurrentQueue<M>> queueMap=new();

        public void QueueDeclare(string queueName)
        {
            var queue=new ConcurrentQueue<M>();
            if(!queueMap.TryAdd(queueName, queue))
            {
                throw new RFMqException("Create queue failed");
            }
        }

        public void Publish(string queueName, M message)
        {
            if(queueMap.TryGetValue(queueName, out var queue))
            {
                queue.Enqueue(message);
                return;
            }
            throw new RFMqException("Message send failed");
        }
        
        public M? NextDelivery(string queueName) {

            if (queueMap.TryGetValue(queueName, out var queue))
            {
                if (queue.TryDequeue(out var message))
                {
                    return message;
                }
            }
            return default;
        }
    }
}