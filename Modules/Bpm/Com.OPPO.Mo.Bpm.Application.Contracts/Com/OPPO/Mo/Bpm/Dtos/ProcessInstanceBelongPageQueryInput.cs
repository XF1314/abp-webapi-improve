using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程实例归属分页查询Input
    /// </summary>
    public class ProcessInstanceBelongPageQueryInput : ProcessInstanceBelongQueryInput, IPageInfo
    {
        /// <summary>
        /// 【选填项】偏移量
        /// </summary>
        public int Offset { get; set; } = 0;

        /// <summary>
        /// 【选填项】数量
        /// </summary>
        public int Count { get; set; } = 20;
    }
}
