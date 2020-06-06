using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Schedule.Custom
{
    public class TrackedBackgoundJobPerformer : IBackgroundJobPerformer
    {
        private readonly IBackgroundJobPerformer _inner;

        public TrackedBackgoundJobPerformer(IBackgroundJobPerformer inner)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public object Perform(PerformContext performContext)
        {
            Console.WriteLine($"Perform {performContext.BackgroundJob.Id}({performContext.BackgroundJob.Job.Type.FullName}.{performContext.BackgroundJob.Job.Method.Name})");
            return _inner.Perform(performContext);
        }
    }
}
