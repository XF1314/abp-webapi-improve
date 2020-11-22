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
using System;
using System.IO;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.ThirdpartyService
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            await CreateHostBuilder(configuration, args).Build().RunAsync();
        }

        internal static IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(loggerBuilder => loggerBuilder.AddExceptionless().AddSerilog().SetMinimumLevel(LogLevel.Debug))
            .ConfigureAppConfiguration(configurationBuilder => configurationBuilder
            .AddApollo(configuration.GetSection("Apollo"))
            .AddNamespace("oppo-it-paas")
            .AddNamespace("megvii")
            .AddNamespace("oppo-sms")
            .AddNamespace("oppo-esb")
            .AddNamespace("feiheair")
            .AddNamespace("oppo-fdc")
            .AddNamespace("oppo-lms")
            .AddNamespace("oppo-jms")
            .AddNamespace("oppo-erp")
            .AddNamespace("oppo-ocsm")
            .AddNamespace("oppo-wifi")
            .AddNamespace("oppo-adap")
            .AddNamespace("oppo-pstst")
            .AddNamespace("oppo-travel")
            .AddNamespace("oppo-datareview")
            .AddNamespace("realme-openapi")
            .AddNamespace("didi-xiaojukeji")
            .AddNamespace("oppo-pre-employment")
            .AddNamespace("oppo-datagrand-search")
            .AddDefault(ConfigFileFormat.Xml)
            .AddDefault(ConfigFileFormat.Json)
            .AddDefault(ConfigFileFormat.Yml)
            .AddDefault(ConfigFileFormat.Yaml)
            .AddDefault())
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
#if DEBUG
            .UseSerilog((x, y) =>
            {
                y.MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .Enrich.WithProperty("Application", configuration["oppo-mo-thirdparty-service-app-name"])
                .Enrich.FromLogContext()
                .WriteTo.File("Logs/log.txt");
            })
#endif
            .UseAutofac();
    }
}
