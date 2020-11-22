using Com.OPPO.Mo.Bpm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Bpm.MongoDB.Repositories
{
    /// <summary>
    /// Mo Mongo仓储
    /// </summary>
    /// <typeparam name="TMongoDbContext"><see cref="IAbpMongoDbContext"/></typeparam>
    /// <typeparam name="TEntity"><see cref="IEntity{TKey}"/></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class MoMongoDbRepository<TMongoDbContext, TEntity, TKey> : MongoDbRepository<TMongoDbContext, TEntity, TKey>, IMoBasicRepository<TEntity, TKey>, IMoBasicRepository<TEntity>
        where TMongoDbContext : IAbpMongoDbContext
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// <see cref="MoMongoDbRepository"/>
        /// </summary>
        public MoMongoDbRepository(IMongoDbContextProvider<TMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        /// <summary>
        /// 获取Queryable对象
        /// </summary>
        /// <returns></returns>
        public new IQueryable<TEntity> GetQueryable()
        {
            return base.GetQueryable();
        }
    }
}
