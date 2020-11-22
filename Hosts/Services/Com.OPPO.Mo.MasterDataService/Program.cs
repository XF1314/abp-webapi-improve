using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Enums;
using Com.OPPO.Mo.ExceptionlessExtensions;
using Exceptionless;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Enums;
using Serilog;
using Serilog.Events;

namespace Com.OPPO.Mo.MasterDataService
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            //TODO: Temporary: it's not good to read appsettings.json here just to configure logging
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            ExceptionlessClient.Default.Configuration.ReadFromConfiguration(configuration);

            try
            {
                ExceptionlessClient.Default
                    .CreateLog("Starting Com.OPPO.Mo.MasterDataService.", Exceptionless.Logging.LogLevel.Info)
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
                .Enrich.WithProperty("Application", configuration["oppo-mo-masterdata-service-app-name"])
                .Enrich.FromLogContext()
                .WriteTo.File("logs/log.txt");
            })
#endif
                .UseAutofac();
    }
}
