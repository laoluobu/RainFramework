using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RainFramework.Dao.PomeloMysql
{
    public static class ServiceProvider
    {

        public static IServiceCollection AddRFPomeloMysql<TDBContext>(this IServiceCollection services, string? connectString) where TDBContext : DbContext
        {
            if (string.IsNullOrEmpty(connectString))
            {
                throw new ArgumentNullException(nameof(connectString));
            }
            return services.AddDbContextPool<TDBContext>(options =>
             {
                 options.UseMySql(connectString, ServerVersion.AutoDetect(connectString),
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure(
                     maxRetryCount: 5,
                     maxRetryDelay: TimeSpan.FromSeconds(30),
                     errorNumbersToAdd: null)
                     .UseNewtonsoftJson()
                     );
                 //打印sql参数
                 options.EnableSensitiveDataLogging();
                 options.EnableDetailedErrors();
             });
        }
    }
}
