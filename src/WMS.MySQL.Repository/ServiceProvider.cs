using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WMS.MySQL.Repository.WMSDB;

namespace WMS.MySQL.Repository
{
    public static class ServiceProvider
    {
        public static void AddMySQLDbPool(this IServiceCollection services, string DbConnectString)
        {
            if (string.IsNullOrEmpty(DbConnectString))
            {
                throw new ArgumentNullException(nameof(DbConnectString));
            }

            services.AddDbContextPool<WMSDBContext>(options =>
            {
                options.UseMySql(DbConnectString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"),
                   optionsBuilder => optionsBuilder.EnableRetryOnFailure(
                    maxRetryCount: 5,
                     maxRetryDelay: TimeSpan.FromSeconds(30),
                       errorNumbersToAdd: null));
            });
        }
    }
}