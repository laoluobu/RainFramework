﻿using Microsoft.Extensions.DependencyInjection;

namespace RainFramework.Cahce
{
    public static class ServiceProvider
    {
        public static IServiceCollection AddRFMemoryCache(this IServiceCollection services, int sizeLimit)
        {
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