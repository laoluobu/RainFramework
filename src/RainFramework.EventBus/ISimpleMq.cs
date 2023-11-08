using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainFramework.Mq
{
    public interface ISimpleMq<M>
    {
        M? NextDelivery(string queueName);
        void Publish(string queueName, M message);
        void QueueDeclare(string queueName);
    }
}
