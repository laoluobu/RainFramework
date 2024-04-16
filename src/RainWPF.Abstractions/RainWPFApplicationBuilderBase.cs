using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RainWPF.Abstractions
{
    public abstract class RainWPFApplicationBuilderBase
    {
        public IServiceCollection Services { get; set; } = null!;
        public IConfigurationRoot Configuration { protected set; get; } = null!;

        public abstract IRWPF Build(params Type[] IgnoreStartService);
    }
}