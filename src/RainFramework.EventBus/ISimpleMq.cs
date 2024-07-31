namespace RainFramework.Mq
{
    public interface ISimpleMq<M>
    {
        void BasicPublish(string queueName, M message);

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
