using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RainWPF.Abstractions;
using System.Windows;

namespace RainWPF
{
    public class RainWPFApplicationBuilder<T> : RainWPFApplicationBuilderBase where T : Application, new()
    {
        private readonly T application;

        internal RainWPFApplicationBuilder(IConfigurationRoot configuration, ServiceCollection services)
        {
            Configuration = configuration;
            application = new T();
            Services = services;
        }

        public override IRWPF Build(params Type[] IgnoreStartService)
        {
            return new RWPF(Services.BuildServiceProvider(), application, IgnoreStartService);
        }
    }

    public class RainWPFApplicationBuilder : RainWPFApplicationBuilderBase
    {
        private readonly Application application;

        internal RainWPFApplicationBuilder(Application application, IConfigurationRoot configuration, ServiceCollection services)
        {            
            Services = services;
            this.application = application;
            Configuration = configuration;
        }

        public override IRWPF Build(params Type[] IgnoreStartService)
        {
            return new RWPF(Services.BuildServiceProvider(), application, IgnoreStartService);
        }
    }
}