using RainWPF;
using System.Windows;

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
            //builder.AddSerilog(builder.Configuration);
            var rwpf = builder.Build();
            rwpf.Run();
        }
    }
}