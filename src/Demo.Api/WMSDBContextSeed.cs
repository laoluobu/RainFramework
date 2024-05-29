using RainFramework.Dao;

namespace Demo.Api
{
    public class WMSDBContextSeed
    {

        public static async Task SeedAsnc(WMSDBContext context, ILogger logger, int retry)
        {
            if (await RFDBContextSeed.SeedAsync(context, logger, retry))
            {
                await context.SaveChangesAsync();
            }

        }
    }
}