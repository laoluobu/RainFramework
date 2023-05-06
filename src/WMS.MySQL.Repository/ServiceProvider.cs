
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WMS.MySQL.Repository
{
    public static class ServiceProvider
    {
        public static void AddMySQLDbPool(this IServiceCollection services,string DbConnectString)
        {
            if (string.IsNullOrEmpty(DbConnectString))
            {
                throw new ArgumentNullException(nameof(DbConnectString));
            }

            services.AddDbContextPool<WMSDB>(options =>
            {
                options.UseMySQL(DbConnectString);
            });
        }
    }
}
