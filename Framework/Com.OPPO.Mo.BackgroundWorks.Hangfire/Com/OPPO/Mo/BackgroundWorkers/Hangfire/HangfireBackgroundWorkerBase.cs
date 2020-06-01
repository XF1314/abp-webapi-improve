using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    public class HangfireBackgroundWorkerBase : BackgroundWorkerBase, IHangfireBackgroundWorker
    {

        public async Task Execute(PerformContext performContext)
        {

            await Task.FromResult(0);
        }
    }
}
