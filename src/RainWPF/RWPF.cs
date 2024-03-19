using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stocker.Helper.Extensions;
using Stocker.Helper.Notification;
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
            UnhandledException();
            Application.Run();
        }

        private void UnhandledException()
        {
            var notificationService = ServiceProvider.GetRequiredService<INotificationService>();
            var logger = ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<RWPF>();
            ///处理Task Exception
            TaskScheduler.UnobservedTaskException += (_, e) =>
            {
                logger.LogError("Task Exception: {GetOriginalException}", e.Exception.GetOriginalException());
                notificationService.ErrorGlobal("[Task] " + e.Exception.GetOriginalException().Message);
            };
            ///处理UI线程Exception
            Application.DispatcherUnhandledException += (_, e) =>
            {
                logger?.LogError("UI Exception: {GetOriginalException}", e.Exception.GetOriginalException());
                notificationService.ErrorGlobal("[UI] " + e.Exception.Message);
                e.Handled = true;
            };

            AppDomain.CurrentDomain.UnhandledException += (_, e) =>
            {
                logger?.LogError("UnhandledException: {GetOriginalException}", ((Exception)e.ExceptionObject).GetOriginalException());
                MessageBox.Show($"{((Exception)e.ExceptionObject).GetOriginalException()}", "Error", MessageBoxButton.OK, icon: MessageBoxImage.Error);
                return;
            };
        }
    }
}