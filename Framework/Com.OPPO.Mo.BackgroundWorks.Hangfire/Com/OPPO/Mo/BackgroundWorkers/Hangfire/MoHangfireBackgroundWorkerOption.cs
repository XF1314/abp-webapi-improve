using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    public class MoHangfireBackgroundWorkerOption
    {
        public MoHangfireBackgroundWorkerOption()
        {
            BackgroundWorkers = new List<HangfireBackgroundWorkerConfig>();
        }

        public List<HangfireBackgroundWorkerConfig> BackgroundWorkers { get; set; }
    }
}
