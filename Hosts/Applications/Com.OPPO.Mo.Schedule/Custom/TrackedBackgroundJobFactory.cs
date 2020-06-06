using Hangfire;
using Hangfire.Annotations;
using Hangfire.Client;
using Hangfire.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Schedule.Custom
{
    public class TrackedBackgroundJobFactory:IBackgroundJobFactory
    {
        private readonly IBackgroundJobFactory _inner;

        public IStateMachine StateMachine => _inner.StateMachine;

        public TrackedBackgroundJobFactory([NotNull] IBackgroundJobFactory inner)
        {
            _inner = inner ?? throw new ArgumentException(nameof(inner));      
        }

        public BackgroundJob Create(CreateContext createContext)
        {
            Console.WriteLine($"Create:{createContext.Job.Type.FullName}.{createContext.Job.Method.Name} in {createContext.InitialState?.Name} state");
            return _inner.Create(createContext);
        }

    }
}
