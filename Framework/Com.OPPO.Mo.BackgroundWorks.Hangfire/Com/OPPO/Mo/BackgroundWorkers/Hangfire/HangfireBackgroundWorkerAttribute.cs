using Hangfire;
using Hangfire.Server;
using Hangfire.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HangfireBackgroundWorkerAttribute : Attribute, IMoHangfireBackgroundWorkderOptions
    {
        /// <summary>
        /// <see cref="HangfireBackgroundWorkerAttribute"/>
        /// </summary>
        /// <param name="workerId">background worker Id，需要保持全局唯一</param>
        /// <param name="cron">cron 表达式 </param>
        public HangfireBackgroundWorkerAttribute(string workerId, string cron)
        {
            WorkerId = workerId;
            Cron = cron;
        }

        public string WorkerId { get; set; }

        public Type WorkerType { get; set; }

        public string Cron { get; set; }

        public TimeZoneInfo TimeZone { get; set; } = TimeZoneInfo.Utc;

        public string QueueName { get; set; } = EnqueuedState.DefaultQueue;

        public IDictionary<string, object> ExtendData { get; set; }

        public bool IsEnabled { get; set; } = true;
    }
}
