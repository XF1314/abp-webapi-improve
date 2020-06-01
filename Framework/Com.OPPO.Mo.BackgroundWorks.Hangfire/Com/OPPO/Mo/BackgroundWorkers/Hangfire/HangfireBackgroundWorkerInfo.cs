using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime;
using System.Text;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    public class HangfireBackgroundWorkerInfo 
    {
        /// <summary>
        /// The identifier of the BackgroundWorker
        /// </summary>
        public string WorkerId { get; set; }

        /// <summary>
        /// Cron expressions
        /// </summary>
        public string Cron { get; set; }

        /// <summary>
        /// TimeZoneInfo
        /// </summary>
        public TimeZoneInfo TimeZone { get; set; }

        /// <summary>
        /// Queue name
        /// </summary>
        public string QueueName { get; set; }

        /// <summary>
        /// Method to execute while <see cref="IHangfireBackgroundWorker.Execute"/> running.
        /// </summary>
        public MethodInfo Method { get; set; }

        /// <summary>
        /// The <see cref="IHangfireBackgroundWorker"/> data persisted in <see cref="PerformContext"/> with server filter <seealso cref="HangfireExtendedDataJobFilter"/>.  
        /// </summary>
        public IDictionary<string, object> ExtendedData { get; set; }

        /// <summary>
        /// Whether the <see cref="IHangfireBackgroundWorker"/> can be added/updated,
        /// default value is true, if false it will be deleted automatically.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Get the full qualified identifier
        /// </summary>
        public string GetFullyQualifiedBackgroundWorkerIdetifier => Method.GetFullyQualifiedName();
    }
}
