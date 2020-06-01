using Hangfire.Common;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    public interface IHangfireBackgroundWorker : IBackgroundWorker
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="performContext"><see cref="PerformContext"/></param>
        /// <returns></returns>
        Task Execute(PerformContext performContext);
    }
}
