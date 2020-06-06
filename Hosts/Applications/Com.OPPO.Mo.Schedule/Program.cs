using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Enums;
using Com.OPPO.Mo.Schedule.Custom;
using Hangfire;
using Hangfire.Client;
using Hangfire.Common;
using Hangfire.Redis;
using Hangfire.Server;
using Hangfire.States;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Schedule
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .Enrich.WithProperty("Application", "Schedule")
                .Enrich.FromLogContext()
                .WriteTo.File("Logs/logs.txt")
                .WriteTo.Elasticsearch(
                new ElasticsearchSinkOptions(new Uri(configuration["ElasticSearch:Url"]))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                    IndexFormat = "mo-schedule-log-{0:yyyy.MM}"
                })
                .CreateLogger();

            try
            {
                Log.Information("Starting Com.OPPO.Mo.Schedule.");
                await CreateHostBuilder(configuration, args).Build().RunAsync();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Com.OPPO.Mo.Schedule terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        internal static IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureLogging(loggerBuilder => loggerBuilder.AddConsole().SetMinimumLevel(LogLevel.Information))
            .ConfigureAppConfiguration(configurationBuilder => configurationBuilder
                .AddApollo(configuration.GetSection("Apollo"))
                .AddDefault(ConfigFileFormat.Xml)
                .AddDefault(ConfigFileFormat.Json)
                .AddDefault(ConfigFileFormat.Yml)
                .AddDefault(ConfigFileFormat.Yaml)
                .AddDefault())
            .ConfigureWebHostDefaults(webBuilder => webBuilder
                .UseUrls(configuration["AppSelfUrl"])
                .UseStartup<Startup>()
                .UseKestrel())
            .UseAutofac()
            .UseSerilog();
    }
}
