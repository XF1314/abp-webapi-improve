using Castle.Core.Logging;
using Com.OPPO.Mo.BackgroundWorkers.Hangfire;
using Hangfire.Server;
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
        private readonly ILogger<DemoBackgroundWorker> _logger;

        public DemoBackgroundWorker(ILogger<DemoBackgroundWorker> logger)
        {
            _logger = logger;
        }

        public async Task Execute(PerformContext performContext)
        {
            _logger.LogInformation(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

            return await Task.FromResult(0);
        }
    }
}
