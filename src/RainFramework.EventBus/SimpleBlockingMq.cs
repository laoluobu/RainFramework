using System.Collections.Concurrent;

namespace RainFramework.EventBus
{
    internal class SimpleBlockingMq<E>
    {
        private BlockingCollection<E> bc;

        public SimpleBlockingMq(int backlog)
        {
            bc = new BlockingCollection<E>(backlog < 1 ? 1 : backlog);
        }



    }
}