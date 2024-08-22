using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using RainFramework.Mq.Exceptions;

namespace RainFramework.Mq
{
    internal class SimpleMq<M> : ISimpleMq<M>
    {
        private ConcurrentDictionary<string, ConcurrentQueue<M>> queueMap = new();

        private readonly ILogger<SimpleMq<M>> logger;

        public SimpleMq(ILogger<SimpleMq<M>> logger)
        {
            this.logger = logger;
        }

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

        public void AllPublish(M message)
        {
            try
            {
                foreach (var queueName in queueMap.Keys)
                {
                    BasicPublish(queueName, message);
                }
            }
            catch
            {
                throw new RFMqException($"Message All Publish failed");
            }
        }


        public M? NextDelivery(string queueName)
        {
            if (!queueMap.ContainsKey(queueName))
            {
                throw new NotFindQueueException(queueName);
            }

            if (queueMap.TryGetValue(queueName, out var queue))
            {
                if (queue.TryDequeue(out var message))
                {
                    return message;
                }
            }
            return default;
        }

        public async void ConsumingMessage(string queueName, Func<M, Task> actions, int interval = 1000)
        {
            using PeriodicTimer timer = new(TimeSpan.FromMilliseconds(interval));
            while (await timer.WaitForNextTickAsync())
            {
                try
                {
                    var message = NextDelivery(queueName);
                    if (message == null)
                    {
                        continue;
                    }
                    await actions.Invoke(message);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "ConsumingMessage Err: {queueName}",queueName);
                }
            }
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