using Hangfire;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    public interface IMoHangfireBackgroundWorkderOptions
    {
        /// <summary>
        /// The worker id represents for <see cref="HangfireBackgroundWorkerInfo.BackgroundWorkerId"/>
        /// which should be unique
        /// </summary>
        string WorkerId { get; set; }

        /// <summary>
        /// The worker type while impl the interface <see cref="IHangfireBackgroundWorker"/>.
        /// </summary>
        Type WorkerType { get; set; }

        /// <summary>
        /// Cron expression
        /// </summary>
        string Cron { get; set; }

        /// <summary>  
        /// The value of <see cref="TimeZoneInfo"/> can be created by <seealso cref="TimeZoneInfo.FindSystemTimeZoneById(string)"/>
        /// </summary>
        TimeZoneInfo TimeZone { get; set; }

        /// <summary>
        /// Hangfire queue name
        /// </summary>
        string QueueName { get; set; }

        /// <summary>
        /// The <see cref="RecurringJob"/> data persisted in <see cref="PerformContext"/> with server filter <seealso cref="HangfireExtendedDataJobFilter"/>.  
        /// </summary>
        public IDictionary<string, object> ExtendData { get; set; }

        /// <summary>
        /// Whether the <see cref="RecurringJob"/> can be added/updated,
        /// default value is true, if false it will be deleted automatically.
        /// </summary>
        bool IsEnabled { get; set; }
    }
}
