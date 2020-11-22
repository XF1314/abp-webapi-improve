using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程实例归属查询Input
    /// </summary>
    public class ProcessInstanceBelongQueryInput
    {
        /// <summary>
        /// 【选填项】流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【选填项】流程实例编码
        /// </summary>
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 【选填项】流程标题
        /// </summary>
        public string ProcessTitle { get; set; }

        /// <summary>
        /// 【选填项】应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 【选填项】是否有效
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 【选填项】创建时间From
        /// </summary>
        public DateTime? CreationTimeFrom { get; set; }

        /// <summary>
        /// 【选填项】创建时间To
        /// </summary>
        public DateTime? CreationTimeTo { get; set; }

    }
}
