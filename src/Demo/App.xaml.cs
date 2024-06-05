using Demo.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using RainWPF;
using System.Windows;
using RainWPF.Serilog;
using Stocker.Helper.Dialog;
using Demo.Dialogs;

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
            var rwpf = builder.Build();
            RegisterDialog(rwpf.ServicesProvider.GetRequiredService<IDialogService>());
        }

        private void RegisterDialog(IDialogService dialogService)
        {
            dialogService.Register<LoginDialogVM, LoginDialog>();
        }
    }
}