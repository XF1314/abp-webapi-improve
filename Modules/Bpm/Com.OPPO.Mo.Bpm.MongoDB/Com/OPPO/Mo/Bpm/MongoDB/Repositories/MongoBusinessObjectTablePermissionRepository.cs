using Com.OPPO.Mo.Bpm.Mongo;
using Com.OPPO.Mo.Bpm.Repositories;
using Com.OPPO.Mo.Queriable;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.MongoDB.Repositories
{
    /// <summary>
    /// Mongo业务对象表权限授权Repository
    /// </summary>
    public class MongoBusinessObjectTablePermissionRepository
        : MoMongoDbRepository<IMoBpmMongoDbContext, BusinessObjectTablePermission, Guid>, IBusinessObjectTablePermissionRepository
    {
        /// <summary>
        /// <see cref="MongoBusinessObjectTablePermissionRepository"/>
        /// </summary>
        public MongoBusinessObjectTablePermissionRepository(IMongoDbContextProvider<IMoBpmMongoDbContext> mongoDbContextProvider) : base(mongoDbContextProvider)
        {

        }

        /// <inheritdoc/>
        public async Task<BusinessObjectTablePermission> GetBusinessObjectTablePermission(string appId, string BusinessObjectTableName)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.AppId == appId && x.BusinessObjectTableName == BusinessObjectTableName && !x.IsDeleted);
        }

    }
}
