namespace RainFramework.Efcore.Exceptions
{
    public class EntityUpdateException : Exception
    {
        public EntityUpdateException(string Message) : base(Message)
        {
        }
    }
}