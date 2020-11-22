using Com.OPPO.Mo.Bpm.Mongo;
using Com.OPPO.Mo.Bpm.Repositories;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.MongoDB.Repositories
{
    /// <summary>
    /// 业务对象归属Mongo仓储
    /// </summary>
    public class MongoBusinessObjectBelongRepository : MoMongoDbRepository<IMoBpmMongoDbContext, BusinessObjectBelong, Guid>, IBusinessObjectBelongRepository
    {
        /// <summary>
        /// <see cref="MongoBusinessObjectBelongRepository"/>
        /// </summary>
        public MongoBusinessObjectBelongRepository(IMongoDbContextProvider<IMoBpmMongoDbContext> mongoDbContextProvider) : base(mongoDbContextProvider)
        {

        }

        /// <inheritdoc/>
        public async Task<BusinessObjectBelong> GetBusinessObjectBelongByBusinessObjectId(string appId, string businessObjectId)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(x => x.AppId == appId && x.BusinessObjectId == businessObjectId && !x.IsDeleted);
        }

        /// <inheritdoc/>
        public async Task<BusinessObjectBelong> GetBusinessObjectBelongByProcessInstanceId(string appId, string businessObjectName, string processInstanceId)
        {
            return await GetMongoQueryable()
               .FirstOrDefaultAsync(x => x.AppId == appId && x.BusinessObjectTableName == x.BusinessObjectTableName && x.ProcessInstanceId == processInstanceId && !x.IsDeleted);
        }
    }
}
