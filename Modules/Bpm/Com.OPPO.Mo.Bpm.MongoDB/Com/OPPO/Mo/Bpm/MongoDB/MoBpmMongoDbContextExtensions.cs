using Com.OPPO.Mo.Bpm.Mongo;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.Mongo
{
    public static class MoBpmMongoDbContextExtensions
    {
        public static void ConfigureIdentity(this IMongoModelBuilder builder, Action<BpmMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));
            var options = new BpmMongoModelBuilderConfigurationOptions(MoBpmDbProperties.DbTablePrefix);

            optionsAction?.Invoke(options);
            builder.Entity<TaskEventMessage>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProcessEventMessages";
            });

            builder.Entity<ProcessLaunchPermission>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProcessLaunchPermissionGrants";
            });
            builder.Entity<BusinessObjectTablePermission>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "BusinessObjectCreatePermissionGrants";
            });

            builder.Entity<ProcessInstanceBelong>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProcessInstanceBelongs";
            });

            builder.Entity<BusinessObjectBelong>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "BusinessObjectBelongs";
            });

            builder.Entity<EaiTaskInstanceBelong>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "EAITaskBelongs";
            });

            builder.Entity<TaskCallbackConfiguration>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProcessCallbackConfigurations";
            });
        }
    }
}
