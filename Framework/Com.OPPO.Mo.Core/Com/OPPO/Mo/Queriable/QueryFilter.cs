using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 查询Filter
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class QueryFilter<TEntity>
    {
        /// <summary>
        /// 条件
        /// </summary>
        public Expression<Func<TEntity, bool>> Predicate { get; set; }

        /// <summary>
        /// <see cref="QueryFilter{TSource}"/>
        /// </summary>
        /// <param name="predicate">条件</param>
        public QueryFilter(Expression<Func<TEntity, bool>> predicate)
        {
            Predicate = predicate;
        }
    }
}
