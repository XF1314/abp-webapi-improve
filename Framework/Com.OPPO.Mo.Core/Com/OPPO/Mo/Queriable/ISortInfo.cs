using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 排序信息
    /// </summary>
    public interface ISortInfo
    {
        /// <summary>
        /// 排序字段s，譬如：['SortNo desc', 'CreateTime desc']
        /// </summary>
        IList<string> SortFields { get; set; }
    }
}
