using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// Eai任务实例归属分页查询Input
    /// </summary>
    public class EaiTaskInstanceBelongPageQueryInput : EaiTaskInstanceBelongQueryInput, IPageInfo
    {
        /// <summary>
        /// 偏移量
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
    }
}
