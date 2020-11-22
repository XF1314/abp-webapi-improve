using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Com.OPPO.Mo.Bpm.Repositories
{
    /// <summary>
    /// Mo基础仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IMoBasicRepository<TEntity> : IBasicRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// 获取Queryable对象
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetQueryable();
    }

    /// <summary>
    /// Mo基础仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IMoBasicRepository<TEntity, TKey> : IMoBasicRepository<TEntity>, IBasicRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {

    }
}
