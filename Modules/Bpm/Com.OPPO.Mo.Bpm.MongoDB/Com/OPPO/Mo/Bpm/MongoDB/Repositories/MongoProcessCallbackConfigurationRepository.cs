using Com.OPPO.Mo.Bpm.Mongo;
using Com.OPPO.Mo.Bpm.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.MongoDB.Repositories
{
    /// <summary>
    /// 流程回调配置Mongo仓储
    /// </summary>
    public class MongoProcessCallbackConfigurationRepository : MoMongoDbRepository<IMoBpmMongoDbContext, ProcessCallbackConfiguration, Guid>, IProcessCallbackConfigurationRepository
    {
        /// <summary>
        /// <see cref="MongoProcessCallbackConfigurationRepository"/>
        /// </summary>
        public MongoProcessCallbackConfigurationRepository(IMongoDbContextProvider<IMoBpmMongoDbContext> mongoDbContextProvider) : base(mongoDbContextProvider)
        {

        }

    }
}