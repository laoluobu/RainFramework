namespace RainFramework.Mq.Exceptions
{
    public class NotFindQueueException : Exception
    {
        public NotFindQueueException()
        {
        }

        public NotFindQueueException(string? message) : base(message)
        {
        }

        public NotFindQueueException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

    }
}
