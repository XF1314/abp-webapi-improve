using System;
using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Hangfire;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Job.Hangfire
{
    [DependsOn(typeof(MoCoreModule))]
    [DependsOn(typeof(AbpHangfireModule))]
    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    public class MoHangfireModule:AbpModule
    {
        /// <inheritdoc/>
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {

        }
        /// <inheritdoc/>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }

        /// <inheritdoc/>
        public override void PostConfigureServices(ServiceConfigurationContext context)
        {

        }

        /// <inheritdoc/>
        public override void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        /// <inheritdoc/>
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
        }

        /// <inheritdoc/>
        public override void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        /// <inheritdoc/>
        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {

        }
    }
}
