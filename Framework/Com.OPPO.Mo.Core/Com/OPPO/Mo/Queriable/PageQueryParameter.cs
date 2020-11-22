using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 分页查询参数
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class PageQueryParameter<TEntity>
    {
        /// <summary>
        /// 排序字段s
        /// </summary>
        public IList<SortField> SortFields { get; set; }

        /// <summary>
        /// <see cref="PageInfo"/>
        /// </summary>
        public PageInfo PageInfo { get; set; }

        /// <summary>
        /// 过滤条件s
        /// </summary>
        public IList<QueryFilter<TEntity>> FilterParameters { get; set; }

        /// <summary>
        /// <see cref="PageQueryParameter{TEntity}"/>
        /// </summary>
        public PageQueryParameter()
        {
            SortFields = new List<SortField>();
            FilterParameters = new List<QueryFilter<TEntity>>();
        }
    }

    /// <summary>
    /// <see cref="PageQueryParameter{TEntity}"/>
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TResult">结果类型</typeparam>
    public class PageQueryParameter<TEntity, TResult> : PageQueryParameter<TEntity>
    {
        /// <summary>
        /// <see cref="TEntity"/>=><see cref="TResult"/>映射关系
        /// </summary>
        public Func<TEntity, TResult> MappingFunction { get; set; }

        /// <summary>
        /// <see cref="PageQueryParameter{TEntity, TResult}"/>
        /// </summary>
        /// <param name="transformFunc"><see cref="TEntity"/>=><see cref="TResult"/>映射关系</param>
        public PageQueryParameter(Func<TEntity, TResult> mappingFunction)
        {
            Check.NotNull(MappingFunction, nameof(mappingFunction));
            MappingFunction = mappingFunction;
        }
    }
}
