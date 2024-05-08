using Demo.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using RainWPF;
using System.Windows;
using RainWPF.Serilog;

namespace Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var builder = RWPF.CreateWPFAppBuilder(Current, false);
            builder.AddSerilog();
            builder.Services.AddSingleton<HomeVM>();
            var rwpf = builder.Build();
            rwpf.Run();
        }
    }
}