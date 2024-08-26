using Microsoft.Extensions.DependencyInjection;

namespace RainFramework.Redis
{
    public static class SeviceProvider
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, string redisConnectionString)
        {
            ArgumentNullException.ThrowIfNull(redisConnectionString);
            return services.AddSingleton<IRedisConnector>(s =>
            {
                return new RedisConnector(redisConnectionString!);
            });
        }
    }
}
