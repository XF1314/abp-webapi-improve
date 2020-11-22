using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Enums;
using Com.OPPO.Mo.ExceptionlessExtensions;
using Com.OPPO.MO.ExceptionlessExtensions;
using Exceptionless;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
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

            ExceptionlessClient.Default.Configuration.ReadFromConfiguration(configuration);

            try
            {
                ExceptionlessClient.Default
                    .CreateLog("Starting Com.OPPO.Mo.Schedule.", Exceptionless.Logging.LogLevel.Info)
                    .Submit();
                await CreateHostBuilder(configuration, args).Build().RunAsync();
                return 0;
            }
            catch (Exception ex)
            {
                ExceptionlessClient.Default.CreateException(ex).Submit();
                return 1;
            }
        }

        internal static IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(loggerBuilder => loggerBuilder.AddConsole().AddExceptionless().AddSerilog().SetMinimumLevel(LogLevel.Information))
            .ConfigureAppConfiguration(configurationBuilder => configurationBuilder
                .AddApollo(configuration.GetSection("Apollo"))
                .AddNamespace("PeopleSoft")
                .AddDefault(ConfigFileFormat.Xml)
                .AddDefault(ConfigFileFormat.Json)
                .AddDefault(ConfigFileFormat.Yml)
                .AddDefault(ConfigFileFormat.Yaml)
                .AddDefault())
            .ConfigureWebHostDefaults(webBuilder => webBuilder
                .UseUrls(configuration["AppSelfUrl"])
                .UseStartup<Startup>()
                .UseKestrel())
#if DEBUG
            .UseSerilog((x, y) =>
            {
                y.MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .Enrich.WithProperty("Application", "Schedule")
                .Enrich.FromLogContext()
                .WriteTo.File("Logs/log.txt");
            })
#endif
            .UseAutofac();


    }
}
