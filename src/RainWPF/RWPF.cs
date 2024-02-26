using System.Diagnostics;
using System.Windows;

namespace RainWPF
{
    public class RWPF
    {
        /// <summary>
        /// 构建WPFApp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isMultiProgram">是否支持多开</param>
        /// <returns></returns>
        public static RainWPFApplicationBuilder<T> CreateWPFAppBuilder<T>(bool isMultiProgram) where T : Application, new()
        {
            if (!isMultiProgram)
            {
                string processName = Process.GetCurrentProcess().ProcessName;
                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length > 1)
                {
                    Environment.Exit(1);
                    MessageBox.Show($"{processName} 已在运行！", "Error", MessageBoxButton.OK, icon: MessageBoxImage.Error);
                }
            }

            return new RainWPFApplicationBuilder<T>();
        }

        public readonly IServiceProvider ServiceProvider;

        public Application Application { get; set; }

        internal RWPF(IServiceProvider ServiceProvider, Application application)
        {
            this.ServiceProvider = ServiceProvider;
            Application = application;
        }

        public void Run()
        {
            Application.Run();
        }
    }
}