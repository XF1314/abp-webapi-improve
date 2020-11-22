using Com.OPPO.Mo.Bpm.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using MongoDB.Driver.Linq;
using Volo.Abp.MongoDB;
using Com.OPPO.Mo.Bpm.Repositories;

namespace Com.OPPO.Mo.Bpm.MongoDB.Repositories
{
    /// <summary>
    /// Eai任务实例归属Mongo仓储
    /// </summary>
    public class MongoEaiTaskInstanceBelongRepository
        : MoMongoDbRepository<IMoBpmMongoDbContext, EaiTaskInstanceBelong, Guid>, IEaiTaskInstanceBelongRepository
    {
        /// <summary>
        /// <see cref="MongoEaiTaskInstanceBelongRepository"/>
        /// </summary>
        public MongoEaiTaskInstanceBelongRepository(IMongoDbContextProvider<IMoBpmMongoDbContext> mongoDbContextProvider) : base(mongoDbContextProvider)
        {

        }

        /// <summary>
        /// 根据任务实例Id获取任务实例归属
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="EaiTaskInstanceId">Eai任务实例Id</param>
        /// <returns></returns>
        public async Task<EaiTaskInstanceBelong> GetTaskInstanceBelongByInstanceId(string appId, string taskInstanceId)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => !x.IsDeleted && x.AppId == appId && x.EaiTaskInstanceId == taskInstanceId);
        }

        /// <summary>
        /// 根据任务业务Id获取任务实例归属
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="taskInstanceId">任务业务Id</param>
        /// <returns></returns>
        public async Task<EaiTaskInstanceBelong> GetTaskInstanceBelongByTaskBizId(string appId, string taskBizId)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => !x.IsDeleted && x.AppId == appId && x.EaiTaskBizId == taskBizId);
        }

    }
}
