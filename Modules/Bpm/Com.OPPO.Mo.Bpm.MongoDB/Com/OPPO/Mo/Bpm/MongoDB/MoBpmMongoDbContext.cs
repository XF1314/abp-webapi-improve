using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.Mongo
{
    [ConnectionStringName(MoBpmDbProperties.ConnectionStringName)]
    public class MoBpmMongoDbContext : AbpMongoDbContext, IMoBpmMongoDbContext
    {
        public IMongoCollection<TaskEventMessage> TaskEventMessages => Collection<TaskEventMessage>();

        public IMongoCollection<ProcessEventMessage> ProcessEventMessages => Collection<ProcessEventMessage>();

        public IMongoCollection<ProcessLaunchPermission> ProcessLaunchPermissions => Collection<ProcessLaunchPermission>();

        public IMongoCollection<BusinessObjectTablePermission> BusinessObjectTablePermissions => Collection<BusinessObjectTablePermission>();

        public IMongoCollection<ProcessInstanceBelong> ProcessInstanceBelongs => Collection<ProcessInstanceBelong>();

        public IMongoCollection<EaiTaskInstanceBelong> EaiTaskInstanceBelongs => Collection<EaiTaskInstanceBelong>();

        public IMongoCollection<TaskCallbackConfiguration> TaskCallbackConfigurations => Collection<TaskCallbackConfiguration>();

        public IMongoCollection<ProcessCallbackConfiguration> ProcessCallbackConfigurations => Collection<ProcessCallbackConfiguration>();

        public IMongoCollection<BusinessObjectBelong> BusinessObjectBelongs => Collection<BusinessObjectBelong>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);
        }
    }
}
