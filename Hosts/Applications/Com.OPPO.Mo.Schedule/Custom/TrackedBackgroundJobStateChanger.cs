using Hangfire.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Schedule.Custom
{
    public class TrackedBackgroundJobStateChanger : IBackgroundJobStateChanger
    {
        private readonly IBackgroundJobStateChanger _inner;

        public TrackedBackgroundJobStateChanger(IBackgroundJobStateChanger inner)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public IState ChangeState(StateChangeContext stateChangeContext)
        {
            Console.WriteLine($"ChangeState {stateChangeContext.BackgroundJobId} to {stateChangeContext.NewState}");
            return _inner.ChangeState(stateChangeContext);
        }

    }
}
