using Com.OPPO.Mo.Bpm.Mongo;
using Com.OPPO.Mo.Bpm.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.MongoDB.Repositories
{
    /// <summary>
    /// 流程事件消息Mongo仓储
    /// </summary>
    public class MongoProcessEventMessageRepository : MoMongoDbRepository<IMoBpmMongoDbContext, ProcessEventMessage, Guid>, IProcessEventMessageRepository
    {
        /// <summary>
        /// <see cref="MongoProcessEventMessageRepository"/>
        /// </summary>
        public MongoProcessEventMessageRepository(IMongoDbContextProvider<IMoBpmMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

