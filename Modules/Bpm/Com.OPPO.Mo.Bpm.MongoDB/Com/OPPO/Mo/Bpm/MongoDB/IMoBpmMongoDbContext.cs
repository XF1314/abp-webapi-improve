using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.Mongo
{
    [ConnectionStringName(MoBpmDbProperties.ConnectionStringName)]
    public interface IMoBpmMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<TaskEventMessage> TaskEventMessages { get; }

        IMongoCollection<ProcessEventMessage> ProcessEventMessages { get; }

        IMongoCollection<ProcessLaunchPermission> ProcessLaunchPermissions { get; }

        IMongoCollection<BusinessObjectTablePermission> BusinessObjectTablePermissions { get; }

        IMongoCollection<ProcessInstanceBelong> ProcessInstanceBelongs { get; }

        IMongoCollection<BusinessObjectBelong> BusinessObjectBelongs { get; }

        IMongoCollection<EaiTaskInstanceBelong> EaiTaskInstanceBelongs { get; }

        IMongoCollection<TaskCallbackConfiguration> TaskCallbackConfigurations { get; }

        IMongoCollection<ProcessCallbackConfiguration> ProcessCallbackConfigurations { get; }
    }
}