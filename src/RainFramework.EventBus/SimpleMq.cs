using System.Collections.Concurrent;

namespace RainFramework.Mq
{
    internal class SimpleMq<M> : ISimpleMq<M>
    {
        private ConcurrentDictionary<string, ConcurrentQueue<M>> queueMap = new();

        public void QueueDeclare(string queueName)
        {
            var queue = new ConcurrentQueue<M>();
            if (!queueMap.TryAdd(queueName, queue))
            {
                throw new RFMqException($"{queueName}:Create queue failed");
            }
        }

        public void BasicPublish(string queueName, M message)
        {
            if (queueMap.TryGetValue(queueName, out var queue))
            {
                queue.Enqueue(message);
                return;
            }
            throw new RFMqException($"{queueName}:Message Publish failed");
        }

        public void MorePublish(string[] queueNames, M message)
        {
            try
            {
                foreach (var queueName in queueNames)
                {
                    BasicPublish(queueName, message);
                }
            }
            catch
            {
                throw new RFMqException($"{string.Join(",", queueNames)} :Message Publish failed");
            }

        }


        public M? NextDelivery(string queueName)
        {

            if (queueMap.TryGetValue(queueName, out var queue))
            {
                if (queue.TryDequeue(out var message))
                {
                    return message;
                }
            }
            return default;
        }

        public IEnumerable<Queueinfo> QueryQueueinfos()
        {
            var ququeInfos = new List<Queueinfo>();
            foreach (var item in queueMap)
            {
                ququeInfos.Add(new Queueinfo() { QueueName = item.Key, Backlog = item.Value.Count() });
            }
            return ququeInfos;
        }
    }
}