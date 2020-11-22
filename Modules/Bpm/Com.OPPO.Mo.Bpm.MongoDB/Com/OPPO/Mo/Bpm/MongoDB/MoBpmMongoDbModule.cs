using Com.OPPO.Mo.Bpm.Mongo;
using Com.OPPO.Mo.Bpm.MongoDB.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.Mongo
{
    [DependsOn(
    typeof(AbpMongoDbModule),
    typeof(MoBpmDomainModule))]
    public class MoBpmMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<MoBpmMongoDbContext>(options =>
            {
                options.AddRepository<BusinessObjectBelong, MongoBusinessObjectBelongRepository>();
                options.AddRepository<EaiTaskInstanceBelong, MongoEaiTaskInstanceBelongRepository>();
                options.AddRepository<TaskCallbackConfiguration, MongoTaskCallbackConfigurationRepository>();
                options.AddRepository<ProcessCallbackConfiguration, MongoProcessCallbackConfigurationRepository>();
                options.AddRepository<TaskEventMessage, MongoTaskEventMessageRepository>();
                options.AddRepository<ProcessEventMessage, MongoProcessEventMessageRepository>();
                options.AddRepository<ProcessInstanceBelong, MongoProcessInstanceBelongRepository>();
                options.AddRepository<ProcessLaunchPermission, MongoTaskCallbackConfigurationRepository>();
                options.AddRepository<BusinessObjectTablePermission, MongoBusinessObjectTablePermissionRepository>();
            });

        }
    }
}
