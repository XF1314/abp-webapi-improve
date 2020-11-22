using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 查询
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class Query<TEntity> : IQuery<TEntity> where TEntity : class
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        [JsonIgnore]
        protected Expression<Func<TEntity, bool>> _filter;

        /// <summary>
        /// 创建一个新的 <see cref="Query{TEntity}"/>
        /// </summary>
        public Query()
        {
            SortFields = new List<string> { };
        }

        /// <summary>
        /// <see cref="Query{TEntity}"/>
        /// </summary>
        /// <param name="filter">查询条件</param>
        public Query(Expression<Func<TEntity, bool>> filter)
        {
            _filter = filter;
        }

        /// <summary>
        /// 排序字段s，譬如：['SortNo desc', 'CreateTime desc']
        /// </summary>
        public IList<string> SortFields { get; set; }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public virtual Expression<Func<TEntity, bool>> GetFilter()
        {
            return _filter.And(this.GetQueryExpression());
        }
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <typeparam name="TEntity">查询Model类型</typeparam>
    public interface IQuery<TEntity> : ISortInfo where TEntity : class
    {
        /// <summary>
        /// 获取查询条件
        /// </summary>
        Expression<Func<TEntity, bool>> GetFilter();
    }
}
