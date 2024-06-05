using System.Windows;
using Demo.Dialogs;
using Demo.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using RainWPF;
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
            var builder = RWPF.CreateWPFAppBuilder( false);
            builder.AddSerilog();
            builder.Services.AddSingleton<HomeVM>();
            var app = builder.Build();
            app.Dialogs.Register<LoginDialogVM, LoginDialog>();
        }
    }
}