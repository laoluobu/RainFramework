using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace RainFramework.Cahce
{
    public static class ServiceProvider
    {
        public static IServiceCollection AddRFMemoryCache(this IServiceCollection services, int sizeLimit)
        {
            Debug.WriteLine($"[AddService] RFMemoryCache sizeLimit={sizeLimit}");
            return services.AddMemoryCache(option =>
            {
                if (sizeLimit > 0)
                {
                    option.SizeLimit = sizeLimit;
                }
            }).AddSingleton<RFMemoryCache>();
        }
    }
}