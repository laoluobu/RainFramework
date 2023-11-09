namespace RainFramework.Mq
{
    public interface ISimpleMq<M>
    {
        void BasicPublish(string queueName, M message);
        void MorePublish(string[] queueNames, M message);
        M? NextDelivery(string queueName);
        IEnumerable<Queueinfo> QueryQueueinfos();
        void QueueDeclare(string queueName);
    }
}
