using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RainWPF.Abstractions;
using Serilog;

namespace RainWPF.Serilog
{
    public static class ServiceProvider
    {
        public static RainWPFApplicationBuilderBase AddSerilog(this RainWPFApplicationBuilderBase builderBase)
        {
            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(builderBase.Configuration)
                            .CreateBootstrapLogger();

            builderBase.Services.AddLogging(logBuiler =>
            {
                logBuiler.ClearProviders();
                logBuiler.AddSerilog();
                
            });
            return builderBase;
        }
    }
}