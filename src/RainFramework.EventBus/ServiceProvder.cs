using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RainFramework.Mq.Options;

namespace RainFramework.Mq
{
    public static class ServiceProvder
    {
        public static IServiceCollection AddSimpeMq<E>(this IServiceCollection services,
                                                            IConfigurationRoot configRoot)
        {
            return services.AddSingleton<ISimpleMq<E>, SimpleMq<E>>()
                           .AddOptions()
                           .Configure<EventBusOption>(e => configRoot.GetSection("RFSimpeMq").Bind(e));
        }
    }
}
