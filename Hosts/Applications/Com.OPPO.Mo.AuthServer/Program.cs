using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Exceptionless;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging;
using Com.OPPO.Mo.ExceptionlessExtensions;
using Serilog;
using Serilog.Events;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Enums;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace Com.OPPO.Mo.AuthServer
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            CreateHostBuilder(configuration, args).Build().RunAsync();
            return Task.CompletedTask;
        }

        internal static IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder
                .UseKestrel(options => { options.Limits.MinRequestBodyDataRate = null; })
                .UseStartup<Startup>())
                .ConfigureLogging(loggerBuilder => loggerBuilder.AddConsole().AddExceptionless().AddSerilog().SetMinimumLevel(LogLevel.Warning))
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
                    .Enrich.WithProperty("Application", configuration["oppo-mo-auth-server-app-name"])
                    .Enrich.FromLogContext()
                    .WriteTo.File("Logs/log.txt");
                })
#endif
                .UseAutofac();
    }
}
