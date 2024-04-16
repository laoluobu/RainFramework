﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RainWPF.Abstractions;
using Serilog;

namespace RainWPF.Serilog
{
    public static class ServiceProvider
    {
        public static RainWPFApplicationBuilderBase AddSerilog(this RainWPFApplicationBuilderBase builderBase, IConfigurationRoot configuration)
        {
            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(configuration)
                            .CreateBootstrapLogger();

            builderBase.Services.AddLogging(logBuiler =>
            {
                logBuiler.ClearProviders();
                logBuiler.AddSerilog();
            });
            return builderBase;
        }
    }
}