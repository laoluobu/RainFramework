namespace RainFramework.Common.CoreException
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string Message) : base(Message)
        {
        }
    }

    public class EntityUpdateException : Exception
    {
        public EntityUpdateException(string Message) : base(Message)
        {
        }
    }
}