using Microsoft.Extensions.DependencyInjection;

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
