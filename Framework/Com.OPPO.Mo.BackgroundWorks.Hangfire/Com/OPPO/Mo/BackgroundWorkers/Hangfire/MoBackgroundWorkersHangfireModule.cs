using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Hangfire;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    [DependsOn(typeof(AbpHangfireModule))]
    [DependsOn(typeof(AbpBackgroundWorkersModule))]
    [DependsOn(typeof(MoCoreModule))]
    public class MoBackgroundWorkersHangfireModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddObjectAccessor(new HangfireBackgroundWorkerInfos());
            context.Services.AddConventionalRegistrar(new MoHangfireConventionalRegistrar());
            context.Services.Configure<MoHangfireBackgroundWorkerOption>(configuration);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }
    }
}
