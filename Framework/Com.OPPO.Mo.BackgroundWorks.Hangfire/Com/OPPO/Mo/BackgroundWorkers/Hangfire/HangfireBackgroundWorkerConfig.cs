using Hangfire;
using Hangfire.Server;
using Hangfire.States;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Reflection;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    public class HangfireBackgroundWorkerConfig : IMoHangfireBackgroundWorkderConfig
    {
        private Type _workerType;

        public string WorkerId { get; set; }

        public WorkerDefinition WorkerDefinition { get; set; }

        public Type WorkerType
        {
            set { _workerType = value; }
            get
            {
                if (_workerType is null && WorkerDefinition != null)
                    _workerType = Assembly.Load(WorkerDefinition.FullQualifiedAssembleName).GetType(WorkerDefinition.FullQualifiedTypeName, true);

                return _workerType;
            }
        }

        public string Cron { get; set; }

        public TimeZoneInfo TimeZone { get; set; } = TimeZoneInfo.Utc;

        public string QueueName { get; set; } = EnqueuedState.DefaultQueue;

        public IDictionary<string, object> ExtendData { get; set; }

        public bool IsEnabled { get; set; } = true;
    }

    public class WorkerDefinition
    {
        public string FullQualifiedAssembleName { get; set; }


        public string FullQualifiedTypeName { get; set; }
    }
}
