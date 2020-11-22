using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Sql
{
    /// <summary>
    /// Stand query language查询比较符，其中：（0-等于；1-不等于；2-小于；3-小于等于；4-大于；5-大于等于）
    /// </summary>
    public enum SqlComparisonOperator
    {
        /// <summary>
        /// 等于
        /// </summary>
        [Description("=")]
        Equal = 0,

        /// <summary>
        /// 不等于
        /// </summary>
        [Description("<>")]
        NotEqual = 1,

        /// <summary>
        /// 小于
        /// </summary>
        [Description("<")]
        LessThan = 2,

        /// <summary>
        /// 小于等于
        /// </summary>
        [Description("<=")]
        LessThanOrEqual = 3,

        /// <summary>
        /// 大于
        /// </summary>
        [Description(">")]
        GreaterThan = 4,

        /// <summary>
        /// 大于等于
        /// </summary>
        [Description(">=")]
        GreaterThanOrEqual = 5,
    }
}