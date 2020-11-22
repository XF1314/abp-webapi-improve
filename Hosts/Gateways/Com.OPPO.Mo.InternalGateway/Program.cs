using System;
using System.IO;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Enums;
using Com.OPPO.Mo.ExceptionlessExtensions;
using Exceptionless;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Com.OPPO.Mo.InternalGateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            await CreateHostBuilder(configuration, args).Build().RunAsync();

            await Task.CompletedTask;
        }

        internal static IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(loggerBuilder => loggerBuilder.AddConsole().AddExceptionless().AddSerilog().SetMinimumLevel(LogLevel.Information))
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .ConfigureAppConfiguration(configurationBuilder => configurationBuilder
                .AddApollo(configuration.GetSection("Apollo"))
                .AddDefault(ConfigFileFormat.Xml)
                .AddDefault(ConfigFileFormat.Json)
                .AddDefault(ConfigFileFormat.Yml)
                .AddDefault(ConfigFileFormat.Yaml)
                .AddDefault())
#if DEBUG
                .UseSerilog((x, y) =>
                {
                    y.MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                    .Enrich.WithProperty("Application", configuration["oppo-mo-internal-gateway-app-name"])
                    .Enrich.FromLogContext()
                    .WriteTo.File("Logs/log.txt");
                })
#endif
                .UseAutofac();
    }
}
