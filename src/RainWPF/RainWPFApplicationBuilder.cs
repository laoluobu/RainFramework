﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace RainWPF
{
    public class RainWPFApplicationBuilder<T> where T : Application, new()
    {
        public IServiceCollection Services { get; set; }
        public IConfigurationRoot Configuration { get; }

        private T application;

        private CancellationTokenSource backgroundHostCTS = new();

        private ServiceProvider serviceProvider;

        private string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        private ILogger<RainWPFApplicationBuilder<T>> logger;

        internal RainWPFApplicationBuilder()
        {
            application = new T();
            Configuration = BuildConfiguration();
            Services = new ServiceCollection();
            application.Exit += Application_Exit;
        }

        public RWPF Build(params Type[] IgnoreStartService)
        {
            serviceProvider = Services.BuildServiceProvider();
            logger = serviceProvider.GetRequiredService<ILogger<RainWPFApplicationBuilder<T>>>();
            _ = StartHostingService(IgnoreStartService);
            ThreadPool.GetMaxThreads(out var workerThreads, out var completionPortThreads);
            logger.LogInformation("App Start ThreadPool MaxThreads: workerThreads={WorkerThreads} ,completionPortThreads={CompletionPortThreads}", workerThreads, completionPortThreads);
            logger.LogInformation("StartUp environment={Environment}", environment);
            return new RWPF(serviceProvider, application);
        }

        private async Task StartHostingService(params Type[] IgnoreStartService)
        {
            foreach (var hostedService in serviceProvider.GetServices<IHostedService>())
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

        private IConfigurationRoot BuildConfiguration()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true)
                                             .AddJsonFile($"appsettings.{environment}.json", optional: true)
                                             .Build();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                backgroundHostCTS.Cancel();
                backgroundHostCTS.Dispose();
                logger.LogInformation("Cancel Background Host");
            }
            catch (Exception ex)
            {
                logger.LogError("Cancel Background Host Err: {Ex}", ex);
            }
        }
    }
}