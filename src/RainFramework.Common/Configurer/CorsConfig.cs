using Microsoft.Extensions.DependencyInjection;

namespace RainFramework.Common.Configurer
{
    public static class CorsConfig
    {
        public static void AddMyCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .SetPreflightMaxAge(TimeSpan.FromHours(5))
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                           
                });
            });
        }
    }
}