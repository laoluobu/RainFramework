using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace RainFramework.Cahce
{
    public static class ServiceProvider
    {
        public static IServiceCollection AddRFMemoryCache(this IServiceCollection services, RFCacheOption rfCacheOption)
        {
            Debug.WriteLine($"[AddService] RFMemoryCache sizeLimit={rfCacheOption.SizeLimit}");
            return services.AddMemoryCache(option =>
            {
                if (rfCacheOption.SizeLimit > 0)
                {
                    option.SizeLimit = rfCacheOption.SizeLimit;
                }
            }).AddSingleton<RFMemoryCache>();
        }
    }
}