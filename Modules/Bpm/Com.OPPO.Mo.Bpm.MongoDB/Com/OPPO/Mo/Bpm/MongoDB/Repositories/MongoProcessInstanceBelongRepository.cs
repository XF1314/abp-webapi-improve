using Com.OPPO.Mo.Bpm.Mongo;
using Com.OPPO.Mo.Bpm.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.MongoDB.Repositories
{
    /// <summary>
    /// 流程实例归属Mongo仓储
    /// </summary>
    public class MongoProcessInstanceBelongRepository :
       MoMongoDbRepository<IMoBpmMongoDbContext, ProcessInstanceBelong, Guid>, IProcessInstanceBelongRepository
    {
        /// <summary>
        /// <see cref="MongoProcessInstanceBelongRepository"/>
        /// </summary>
        public MongoProcessInstanceBelongRepository(IMongoDbContextProvider<IMoBpmMongoDbContext> mongoDbContextProvider) : base(mongoDbContextProvider)
        {

        }

        /// <inheritdoc/>
        public async Task<ProcessInstanceBelong> GetProcessInstanceBelongByInstanceId(string appId, string processInstanceId)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(x => x.AppId == appId && x.ProcessInstanceId == processInstanceId && !x.IsDeleted);
        }

        /// <inheritdoc/>
        public async Task<List<ProcessInstanceBelong>> GetProcessInstanceBelongsByInstanceIds(string appId, List<string> processInstanceIds)
        {
            //var filter = Builders<ProcessInstanceBelong>.Filter;
            //var sk = await Collection.Find(filter.Where(x => processInstanceIds.Contains(x.ProcessInstanceId))).ToListAsync();
            //var ss = await Collection.Find("{ ProcessInstanceId : { $in : ['d774461a-b65d-490a-a3a8-748deefb0830', '0c13dfdc-3ea6-4538-823b-c25b83b6e8ab'] } }").ToListAsync(); 
            return await GetMongoQueryable()
                .Where(x => x.AppId == appId && processInstanceIds.Contains(x.ProcessInstanceId) && !x.IsDeleted)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<ProcessInstanceBelong> GetProcessInstanceBelongByInstanceCode(string appId, string processInstanceCode)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(x => x.AppId == appId && x.ProcessInstanceCode == processInstanceCode && !x.IsDeleted);
        }

        /// <inheritdoc/>
        public async Task<List<ProcessInstanceBelong>> GetProcessInstanceBelongsByInstanceCodes(string appId, List<string> processInstanceCodes)
        {
            return await GetMongoQueryable()
                .Where(x => x.AppId == appId && processInstanceCodes.Contains(x.ProcessInstanceCode) && !x.IsDeleted)
                .ToListAsync();
        }
    }
}
