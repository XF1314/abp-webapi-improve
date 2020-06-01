using Hangfire;
using Hangfire.Server;
using Hangfire.States;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    public class MoHangfireBackgroundWorkerOptions : IOptions<MoHangfireBackgroundWorkerOptions>, IMoHangfireBackgroundWorkderOptions
    {
        [JsonRequired]
        [JsonProperty("worker-id")]
        public string WorkerId { get; set; }

        [JsonRequired]
        [JsonProperty("worker-type")]
        public Type WorkerType { get; set; }

        [JsonRequired]
        [JsonProperty("cron-expression")]
        public string Cron { get; set; }

        [JsonProperty("timezone")]
        [JsonConverter(typeof(TimeZoneInfoJsonConverter))]
        public TimeZoneInfo TimeZone { get; set; } = TimeZoneInfo.Utc;

        [JsonProperty("queue-name")]
        public string QueueName { get; set; } = EnqueuedState.DefaultQueue;

        [JsonProperty("worker-data")]
        public IDictionary<string, object> ExtendData { get; set; }

        [JsonProperty("is-enabled")]
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc/>
        [JsonIgnore]
        public MoHangfireBackgroundWorkerOptions Value => this;

    }
}
