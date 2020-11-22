using Com.OPPO.Mo.Bpm.Mongo;
using Com.OPPO.Mo.Bpm.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.MongoDB.Repositories
{
    /// <summary>
    /// 任务回调配置Mongo仓储
    /// </summary>
    public class MongoTaskCallbackConfigurationRepository
       : MoMongoDbRepository<IMoBpmMongoDbContext, TaskCallbackConfiguration, Guid>, ITaskCallbackConfigurationRepository
    {
        /// <summary>
        /// <see cref="MongoTaskCallbackConfigurationRepository"/>
        /// </summary>
        public MongoTaskCallbackConfigurationRepository(IMongoDbContextProvider<IMoBpmMongoDbContext> mongoDbContextProvider) : base(mongoDbContextProvider)
        {

        }

    }
}
