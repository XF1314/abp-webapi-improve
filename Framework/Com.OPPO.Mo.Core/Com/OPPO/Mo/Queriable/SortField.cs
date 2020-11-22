using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 排序字段
    /// </summary>
    public class SortField
    {
        ///// <summary>
        ///// 字段名
        ///// </summary>
        //public string FieldName { get; set; }

        /// <summary>
        /// <see cref="SortType"/>
        /// </summary>
        public SortType SortType { get; set; }

        /// <summary>
        /// 字段Selector表达式
        /// </summary>
        public LambdaExpression Selector { get; set; }

        /// <inheritdoc/>
        public SortField(LambdaExpression selector, SortType sortType)
        {
            Selector = selector;
            SortType = sortType;
        }
    }
}
