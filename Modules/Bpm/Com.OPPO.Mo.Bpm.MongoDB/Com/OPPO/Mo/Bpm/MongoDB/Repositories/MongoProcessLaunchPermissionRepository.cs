using Com.OPPO.Mo.Bpm.Mongo;
using Com.OPPO.Mo.Bpm.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.MongoDB.Repositories
{
    /// <summary>
    /// 流程发起权限Mongo仓储
    /// </summary>
    public class MongoProcessLaunchPermissionRepository
        : MoMongoDbRepository<IMoBpmMongoDbContext, ProcessLaunchPermission, Guid>, IProcessLaunchPermissionRepository
    {
        /// <summary>
        /// <see cref="MongoProcessLaunchPermissionRepository"/>
        /// </summary>
        public MongoProcessLaunchPermissionRepository(IMongoDbContextProvider<IMoBpmMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <inheritdoc />
        public async Task<ProcessLaunchPermission> GetProcessLaunchPermission(string appId, string processDefinitionId)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.AppId == appId && x.ProcessDefinitionId == processDefinitionId && !x.IsDeleted);
        }
    }
}
