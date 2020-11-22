using Com.OPPO.Mo.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 查询Attribute，仅适用于属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class QueryAttribute : Attribute
    {
        /// <summary>
        /// <see cref="QueryAttribute"/>
        /// </summary>
        public QueryAttribute(QueryComparisonOperator comparisonOperator, params string[] propertyPath)
        {
            PropertyPath = propertyPath;
            ComparisonOperator = comparisonOperator;
        }

        /// <summary>
        /// <see cref="QueryComparisonOperator"/>
        /// </summary>
        public QueryComparisonOperator ComparisonOperator { get; set; }

        /// <summary>
        /// 对应属性路径
        /// </summary>
        public string[] PropertyPath { get; set; }

        /// <summary>
        /// 查询字段
        /// </summary>
        public QueryAttribute(params string[] propertyPath)
        {
            PropertyPath = propertyPath;
        }
    }
}
