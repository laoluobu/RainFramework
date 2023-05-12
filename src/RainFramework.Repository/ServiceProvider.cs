using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WMS.Repository.DBContext;

namespace RainFramework.Repository
{
    public static class ServiceProvider
    {
        public static void AddMySQLDbPool(this IServiceCollection services, string DbConnectString)
        {
            if (string.IsNullOrEmpty(DbConnectString))
            {
                throw new ArgumentNullException(nameof(DbConnectString));
            }

            services.AddDbContextPool<MySqlContext>(options =>
            {
                options.UseMySql(DbConnectString, ServerVersion.Parse("8.0.33-mysql"),
                   optionsBuilder => optionsBuilder.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null).UseNewtonsoftJson());

                //打印sql参数
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });
        }
    }
}