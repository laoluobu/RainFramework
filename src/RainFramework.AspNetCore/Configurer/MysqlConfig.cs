using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WMS.Repository.DBContext;

namespace RainFramework.AspNetCore.Configurer
{
    internal static class MysqlConfig
    {
        public static void AddMySQLDbPool(this IServiceCollection services, string DbConnectString)
        {
            if (string.IsNullOrEmpty(DbConnectString))
            {
                throw new ArgumentNullException(nameof(DbConnectString));
            }

            services.AddDbContextPool<WMSDBContext>(options =>
            {
                options.UseMySql(DbConnectString, ServerVersion.Parse("8.0.33-mysql"),
                   optionsBuilder => optionsBuilder.EnableRetryOnFailure(
                    maxRetryCount: 5,
                     maxRetryDelay: TimeSpan.FromSeconds(30),
                   errorNumbersToAdd: null));

                //打印sql参数
                //打印sql参数
                options.EnableSensitiveDataLogging();
            });
        }
    }
}