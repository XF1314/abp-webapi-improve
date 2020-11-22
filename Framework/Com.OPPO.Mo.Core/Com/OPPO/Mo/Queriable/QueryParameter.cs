using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 查询参数
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class QueryParameter<TEntity>
    {
        /// <summary>
        /// 排序字段s
        /// </summary>
        public IList<SortField> SortFields { get; set; }

        /// <summary>
        /// 过滤器s
        /// </summary>
        public IList<QueryFilter<TEntity>> Filters { get; set; }

        /// <summary>
        /// <see cref="QueryParameter{TEntity}"/>
        /// </summary>
        public QueryParameter()
        {
            SortFields = new List<SortField>();
            Filters = new List<QueryFilter<TEntity>>();
        }
    }

    /// <summary>
    /// <see cref="QueryParameter{TEntity}"/>
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TResult">结果类型</typeparam>
    public class QueryParameter<TEntity, TResult> : QueryParameter<TEntity>
    {
        /// <summary>
        /// <see cref="TEntity"/>=><see cref="TResult"/>映射关系
        /// </summary>
        public Func<TEntity, TResult> MappingFunction { get; set; }

        /// <summary>
        /// <see cref="QueryResult{T}"/>
        /// </summary>
        /// <param name="transformFunc"><see cref="TEntity"/>=><see cref="TResult"/>映射关系</param>
        public QueryParameter(Func<TEntity, TResult> mappingFunction)
        {
            Check.NotNull(MappingFunction, nameof(mappingFunction));
            MappingFunction = mappingFunction;
        }
    }
}
