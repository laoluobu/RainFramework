using Microsoft.Extensions.DependencyInjection;
using RainFramework.EventBus;

namespace RainFramework.Mq
{
    public static class ServiceProvder
    {
        public static IServiceCollection AddSimpeMq<E>(this IServiceCollection services)
        {
            return services.AddSingleton<ISimpleMq<E>, SimpleMq<E>>();
        }
    }
}
