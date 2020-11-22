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
    /// 任务事件消息Mongo仓储
    /// </summary>
    public class MongoTaskEventMessageRepository
        : MoMongoDbRepository<IMoBpmMongoDbContext, TaskEventMessage, Guid>, ITaskEventMessageRepository
    {
        /// <summary>
        /// <see cref="MongoTaskEventMessageRepository"/>
        /// </summary>
        public MongoTaskEventMessageRepository(IMongoDbContextProvider<IMoBpmMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
