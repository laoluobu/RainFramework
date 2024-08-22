﻿
namespace RainFramework.Mq
{
    public interface ISimpleMq<M>
    {
        void BasicPublish(string queueName, M message);
        void ConsumingMessage(string queueName, Func<M?, Task> actions, int interval = 1000);
        void MorePublish(string[] queueNames, M message);


        M? NextDelivery(string queueName);

        IEnumerable<Queueinfo> QueryQueueinfos();

        /// <summary>
        /// 生命队列
        /// </summary>
        /// <param name="queueName"></param>
        void QueueDeclare(string queueName);
    }
}
