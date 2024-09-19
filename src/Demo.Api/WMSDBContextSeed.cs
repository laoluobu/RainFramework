using RainFramework.Dao;

namespace Demo.Api
{
    public class WMSDBContextSeed
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<WMSDBContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<WMSDBContextSeed>>();
            if (await RFDBContextSeed.SeedAsync(dbContext, logger))
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }
}