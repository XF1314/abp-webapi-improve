using Castle.Core.Logging;
using Com.Ctrip.Framework.Apollo;
using Com.OPPO.Mo.BackgroundWorkers.Hangfire;
using Hangfire.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;

namespace Com.OPPO.Mo.Schedule.BackgroundWorkers
{
    public class DemoBackgroundWorker : BackgroundWorkerBase, IHangfireBackgroundWorker
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DemoBackgroundWorker> _logger;

        public DemoBackgroundWorker(IConfiguration configuration, ILogger<DemoBackgroundWorker> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task Execute(PerformContext performContext)
        {
            var ss = _configuration["TestKey"];
            Console.WriteLine(_configuration["TestKey"]);
            _logger.LogInformation(_configuration["TestKey"]);
            _logger.LogInformation(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

            await Task.FromResult(0);
        }
    }
}
