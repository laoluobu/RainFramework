using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RainFramework.Mq.Options;

namespace RainFramework.Mq
{
    public static class ServiceProvder
    {
        public static IServiceCollection AddSimpeMq<E>(this IServiceCollection services,
                                                            IConfiguration configRoot)
        {
            var option = configRoot.GetSection("RFSimpeMq");
            if (option.Value == null)
            {
                throw new NullReferenceException("in configuration 'RFSimpeMq' is null");
            }
            return services.AddSingleton<ISimpleMq<E>, SimpleMq<E>>()
                           .AddOptions()
                           .Configure<EventBusOption>(e => option.Bind(e));
        }
    }
}
