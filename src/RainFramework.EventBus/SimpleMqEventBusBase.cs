﻿using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RainFramework.Common.Moudels.TO;
using RainFramework.Mq.Options;

namespace RainFramework.Mq
{
    public abstract class SimpleMqEventBusBase
    {
        protected readonly ILogger<SimpleMqEventBusBase> logger;
        protected readonly ISimpleMq<MessageTO> mq;
        protected readonly EventBusOption option;

        protected SimpleMqEventBusBase(ILogger<SimpleMqEventBusBase> logger, IOptions<EventBusOption> options, ISimpleMq<MessageTO> mq)
        {
            this.logger = logger;
            this.mq = mq;
            option = options.Value;

            foreach (var ququeName in option.QueueNames)
            {
                mq.QueueDeclare(ququeName);
            }
        }

        protected void PublishMessage(object context, [CallerMemberName] string name = "Unknown")
        {
            try
            {
                var message = new MessageTO()
                {
                    Name = name,
                    Context = context
                };
                mq.AllPublish(message);
            }
            catch (Exception ex)
            {
                logger.LogError("PublishMessage EX: {Ex}", ex);
            }
        }
    }
}