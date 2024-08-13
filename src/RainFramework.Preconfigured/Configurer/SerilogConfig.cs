using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;

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


        public static void UseHttpRequestLogging(this WebApplication application)
        {
            application.UseSerilogRequestLogging(option =>
            {
                option.MessageTemplate = "[ApiOperate] User {UserName} ClientIp {ClientIp} " + option.MessageTemplate;

                option.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Information;

                option.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("UserName", httpContext.User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value ?? "None");
                    diagnosticContext.Set("ClientIp", httpContext.Connection.RemoteIpAddress?.MapToIPv4());
                };
            });
        }
    }
}