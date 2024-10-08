﻿using System.Collections.Concurrent;

namespace RainFramework.Mq
{
    internal class SimpleBlockingMq<E>
    {
        private BlockingCollection<E> bc;

        public SimpleBlockingMq(int backlog)
        {
            bc = new BlockingCollection<E>(backlog < 1 ? 1 : backlog);
        }

        public void BasicPublish(string queueName, E message)
        {
            bc.Add(message);
            //bc.GetConsumingEnumerable
        }
    }
}