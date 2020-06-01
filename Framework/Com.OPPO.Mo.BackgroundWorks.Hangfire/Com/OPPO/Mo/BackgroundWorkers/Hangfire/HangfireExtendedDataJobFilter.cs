using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Hangfire.Server;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    //[ExposeServices(typeof(HangfireExtendedDataJobFilter))]
    public class HangfireExtendedDataJobFilter : IServerFilter//, ISingletonDependency
    {
        private readonly ObjectAccessor<HangfireBackgroundWorkerInfos> _hangfireBackgroundWorkerAccessor;

        public HangfireExtendedDataJobFilter(ObjectAccessor<HangfireBackgroundWorkerInfos> objectAccessor)
        {
            _hangfireBackgroundWorkerAccessor = objectAccessor;
        }

        public void OnPerforming(PerformingContext filterContext)
        {
            if (_hangfireBackgroundWorkerAccessor.Value.Any(x => x.WorkerId == filterContext.BackgroundJob.Id))
            {
                var backgroundWorkerInfos = _hangfireBackgroundWorkerAccessor.Value.FindAll(x => x.WorkerId == filterContext.BackgroundJob.Id);
                backgroundWorkerInfos.ForEach(y =>
                {
                    var jobDataKey = $"backgroundJob-info-{y}";
                    if (y.ExtendedData == null)
                        y.ExtendedData = new Dictionary<string, object>();

                    filterContext.Items[jobDataKey] = y.ExtendedData;
                });
            }
        }

        public void OnPerformed(PerformedContext filterContext)
        {
            //do nothing?
        }

    }
}
