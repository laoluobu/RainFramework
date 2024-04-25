using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RainWPF.Abstractions;
using RainWPF.Core;
using RainWPF.Helper;
using Stocker.Helper.Dialog;
using Stocker.Helper.Extensions;
using Stocker.Helper.Notification;

namespace RainWPF
{
    public class RWPF : IRWPF
    {
        internal static IServiceProvider? ProxyServicesProvider;

        public IServiceProvider ServicesProvider { get; private set; }

        public IDialogService DialogService { get; private set; }

        public Application Application { get; set; }

        private readonly CancellationTokenSource backgroundHostCTS = new();

        private readonly ILogger<RWPF> logger;

        public static string Environment => System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        private static bool isInstance;

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
                WPFHelper.NotAllowMultiProgram();
            }
            return new RainWPFApplicationBuilder<T>(BuildConfiguration(), BuilderBasicsService());
        }

        /// <summary>
        /// 构建WPFApp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isMultiProgram">是否支持多开</param>
        /// <returns></returns>
        public static RainWPFApplicationBuilder CreateWPFAppBuilder(Application application, bool isMultiProgram)
        {
            if (!isMultiProgram)
            {
                WPFHelper.NotAllowMultiProgram();
            }
            isInstance = true;
            return new RainWPFApplicationBuilder(application, BuildConfiguration(), BuilderBasicsService());
        }

        private static ServiceCollection BuilderBasicsService()
        {
            var Services = new ServiceCollection();
            Services.AddLogging(builder =>
            {
                builder.AddDebug();
            });
            Services.AddSingleton<IDialogService, DialogService>()
                    .AddSingleton<INotificationService, NotificationService>();
            return Services;
        }

        internal RWPF(IServiceProvider serviceProvider, Application application, Type[] IgnoreStartService)
        {
            ProxyServicesProvider = serviceProvider;
            ServicesProvider = serviceProvider;
            DialogService = ServicesProvider.GetRequiredService<IDialogService>();
            var loggerFactory = ServicesProvider.GetRequiredService<ILoggerFactory>();
            logger = loggerFactory.CreateLogger<RWPF>();
            Application = application;
            application.Exit += Application_Exit;
            UnhandledException();
            _ = StartHostingService(IgnoreStartService);
            ThreadPool.GetMaxThreads(out var workerThreads, out var completionPortThreads);
            logger.LogInformation("App Start ThreadPool MaxThreads: workerThreads={WorkerThreads} ,completionPortThreads={CompletionPortThreads}", workerThreads, completionPortThreads);
            logger.LogInformation("StartUp environment={Environment}", Environment);
        }

        public void Run()
        {
            if (isInstance)
            {
                return;
            }
            Application.Run();
        }

        private async Task StartHostingService(params Type[] IgnoreStartService)
        {
            foreach (var hostedService in ServicesProvider.GetServices<IHostedService>())
            {
                var type = hostedService.GetType();
                if (IgnoreStartService.Contains(type))
                {
                    logger.LogDebug("[StartHosting] Ignore start {Type}", type);
                    continue;
                }
                await hostedService.StartAsync(backgroundHostCTS.Token);
                logger.LogInformation("[StartHosting] {Type} Started", type);
            }
        }

        private void UnhandledException()
        {
            var notificationService = ServicesProvider.GetRequiredService<INotificationService>();
            var logger = ServicesProvider.GetRequiredService<ILoggerFactory>().CreateLogger<RWPF>();
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

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                backgroundHostCTS.Cancel();
                backgroundHostCTS.Dispose();
                logger.LogInformation("Cancel Background Host");
                logger.LogInformation("App exit!");
            }
            catch (Exception ex)
            {
                logger.LogError("Cancel Background Host Err: {Ex}", ex);
            }
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true)
                             .AddJsonFile($"appsettings.{Environment}.json", optional: true)
                             .Build();
        }
    }
}