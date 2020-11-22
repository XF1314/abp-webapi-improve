using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class QueryableExtension
    {
        /// <summary>
        /// to query result as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>Task&lt;QueryResult&lt;TSource&gt;&gt;.</returns>
        public static async Task<PageQueryResult<TSource>> ToPageQueryResultAsync<TSource>(this IQueryable<TSource> queryable, PageQueryParameter<TSource> pageQueryParameter)
            where TSource : class, new()
        {
            var totalCount = 0;
            queryable = queryable.FullfillPageQueryParameter(pageQueryParameter, out totalCount);
            var records = await queryable.ToDynamicListAsync<TSource>();

            return new PageQueryResult<TSource>(records, totalCount, pageQueryParameter.PageInfo);
        }

        public static async Task<PageQueryResult<TResult>> ToPageQueryResult<TSource, TResult>(this IQueryable<TSource> queryable, PageQueryParameter<TSource> pageQueryParameter, Func<TSource, TResult> mappingFunction)
            where TSource : class, new()
            where TResult : class, new()
        {
            var totalCount = 0;
            queryable = queryable.FullfillPageQueryParameter(pageQueryParameter, out totalCount);
            var records = (await queryable.ToDynamicListAsync<TSource>()).Select(mappingFunction).ToList();

            return new PageQueryResult<TResult>(records, totalCount, pageQueryParameter.PageInfo);
        }

        public static async Task<QueryResult<TSource>> ToQueryResultAsync<TSource>(this IQueryable<TSource> queryable, QueryParameter<TSource> queryParameter) where TSource : class, new()
        {
            queryable = queryable.FullfillQueryParameter(queryParameter);
            var records = await queryable.ToDynamicListAsync<TSource>();

            return new QueryResult<TSource>(records);
        }

        public static async Task<QueryResult<TResult>> ToQueryResult<TSource, TResult>(this IQueryable<TSource> queryable, QueryParameter<TSource> queryParameter, Func<TSource, TResult> mappingFunction)
            where TSource : class, new()
            where TResult : class, new()
        {
            queryable = queryable.FullfillQueryParameter(queryParameter);
            var records = (await queryable.ToDynamicListAsync<TSource>()).Select(mappingFunction).ToList();

            return new QueryResult<TResult>(records);
        }

        private static IQueryable<TSource> FullfillPageQueryParameter<TSource>(this IQueryable<TSource> queryable, PageQueryParameter<TSource> pageQueryParameter, out int totalCount) where TSource : class, new()
        {
            //contact filters
            foreach (var queryFilter in pageQueryParameter.FilterParameters)
                queryable = queryable.Where(queryFilter.Predicate);
            totalCount = queryable.Count();

            //sort
            if (pageQueryParameter.SortFields.Any())
            {
                for (int i = 0; i < pageQueryParameter.SortFields.Count; i++)
                    queryable = FullfillOrderInfo(queryable, pageQueryParameter.SortFields.ElementAt(i), i == 0);
            }

            //pageable
            if (pageQueryParameter.PageInfo != null && pageQueryParameter.PageInfo.Count > 0)
                queryable = queryable.Skip(pageQueryParameter.PageInfo.Offset).Take(pageQueryParameter.PageInfo.Count);

            return queryable;
        }

        private static IQueryable<TSource> FullfillQueryParameter<TSource>(this IQueryable<TSource> queryable, QueryParameter<TSource> queryParameter) where TSource : class, new()
        {
            //contact filters
            foreach (var queryFilter in queryParameter.Filters)
                queryable = queryable.Where(queryFilter.Predicate);

            //sort
            if (queryParameter.SortFields.Any())
            {
                for (int i = 0; i < queryParameter.SortFields.Count; i++)
                    queryable = FullfillOrderInfo(queryable, queryParameter.SortFields.ElementAt(i), i == 0);
            }

            return queryable;
        }

        private static IQueryable<TSource> FullfillOrderInfo<TSource>(IQueryable<TSource> queryable, SortField sortField, bool isFirst)
        {
            var expression = Expression.Call(typeof(Queryable), GetSortMethodName(sortField.SortType, isFirst),
                new Type[] { queryable.ElementType, sortField.Selector.Body.Type },
                new Expression[] { queryable.Expression, Expression.Quote(sortField.Selector) });

            queryable = queryable.Provider.CreateQuery<TSource>(expression);

            return queryable;
        }

        private static string GetSortMethodName(SortType sortType, bool isFirst)
        {
            string methodName;
            switch (sortType)
            {
                case SortType.Asc:
                    methodName = isFirst ? nameof(Queryable.OrderBy) : nameof(Queryable.ThenBy);
                    break;
                case SortType.Desc:
                    methodName = isFirst ? nameof(Queryable.OrderByDescending) : nameof(Queryable.ThenByDescending);
                    break;

                default:
                    methodName = nameof(Queryable.OrderBy);
                    break;
            }

            return methodName;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="queryable"><see cref="IQueryable{T}"/></param>
        /// <param name="offset">从第几条记录开始，不能小于0</param>
        /// <param name="count">取多少条记录，不能小于1</param>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> queryable, int offset, int count)
        {
            if (queryable == null)
                throw new ArgumentNullException("query");

            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset", "偏移量不能小于0");

            if (count < 1)
                throw new ArgumentOutOfRangeException("count", "数量不能小于1");

            return queryable.Skip(offset).Take(count);
        }

        /// <summary>
        /// 如果条件 <paramref name="condition"/> 为 true， 根据指定的过滤器 <paramref name="predicate"/> 筛选集合
        /// </summary>
        /// <param name="query">查询的数据集</param>
        /// <param name="condition">是否过滤</param>
        /// <param name="predicate">过滤器</param>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }

        /// <summary>
        /// 如果条件 <paramref name="condition"/> 为 true， 根据指定的过滤器 <paramref name="predicate"/> 筛选集合
        /// </summary>
        /// <param name="query">查询的数据集</param>
        /// <param name="condition">是否过滤</param>
        /// <param name="predicate">过滤器</param>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }

        /// <summary>
        /// 拼接 and 条件语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            if (first == null) return second;
            if (second == null) return first;

            return ParameterRebinder.Compose(first, second, Expression.And);
        }

        /// <summary>
        /// 拼接 or 条件语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            if (first == null) return second;
            if (second == null) return first;

            return ParameterRebinder.Compose(first, second, Expression.Or);
        }
    }
}
