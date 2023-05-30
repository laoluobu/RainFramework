using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RainFramework.Repository.DBContext;

namespace RainFramework.Repository
{
    public static class ServiceProvider
    {
        /// <summary>
        /// 提供连接池
        /// </summary>
        /// <param name="services"></param>
        /// <param name="DbConnectString"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddMySQLDbPool(this IServiceCollection services, string DbConnectString)
        {
            if (string.IsNullOrEmpty(DbConnectString))
            {
                throw new ArgumentNullException(nameof(DbConnectString));
            }

            services.AddDbContextPool<BaseDBContext>(options =>
            {
                options.UseMySql(DbConnectString, ServerVersion.Parse("8.0.33-mysql"),
                   optionsBuilder => optionsBuilder.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null)
                    .UseNewtonsoftJson()
                    .MigrationsAssembly("RainFramework.Repository"));
                //打印sql参数
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });
        }

        /// <summary>
        /// 普通连接
        /// </summary>
        /// <param name="services"></param>
        /// <param name="DbConnectString"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddBaseDBContext(this IServiceCollection services, string DbConnectString)
        {
            if (string.IsNullOrEmpty(DbConnectString))
            {
                throw new ArgumentNullException(nameof(DbConnectString));
            }
            services.AddDbContext<BaseDBContext>(
                options =>
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