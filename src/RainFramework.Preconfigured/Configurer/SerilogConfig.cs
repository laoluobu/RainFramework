using Microsoft.AspNetCore.Builder;
using Serilog;

namespace RainFramework.Preconfigured.Configurer
{
    public static class SerilogConfig
    {
        public static void UseSerilogger(this ConfigureHostBuilder Host)
        {
            Host.UseSerilog((context, logging) =>
            {
                logging.ReadFrom.Configuration(context.Configuration);
                logging.Enrich.FromLogContext();
            });
        }
    }
}