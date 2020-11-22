using Exceptionless;
using Exceptionless.Queue;
using Exceptionless.Submission;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using Exceptionless.Dependency;

namespace Com.OPPO.Mo.ExceptionlessExtensions
{
    [DependsOn(typeof(MoCoreModule))]
    public class MoExceptionlessModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ExceptionlessClient.Default.Configuration.Resolver.Register<IEventQueue, MoEventQueue>();
            ExceptionlessClient.Default.Configuration.Resolver.Register<ISubmissionClient, MoSubmissionClient>();
        }


    }
}
