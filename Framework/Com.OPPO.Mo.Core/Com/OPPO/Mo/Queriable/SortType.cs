using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 排序类型,其中（ 1-升序； 2-降序）
    /// </summary>
    public enum SortType
    {
        /// <summary>
        /// 升序
        /// </summary>
        [Description("升序")]
        Asc = 1,

        /// <summary>
        /// 降序
        /// </summary>
        [Description("降序")]
        Desc = 2
    }
}
