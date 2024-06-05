using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RainWPF.Abstractions;

namespace RainWPF
{
    public class RainWPFApplicationBuilder : RainWPFApplicationBuilderBase
    {
        internal RainWPFApplicationBuilder(IConfigurationRoot configuration, ServiceCollection services)
        {
            Configuration = configuration;           
            Services = services;
        }

        public override IRWPF Build(params Type[] IgnoreStartService)
        {
            return new RWPF(Services.BuildServiceProvider(), IgnoreStartService);
        }
    }
}