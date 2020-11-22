using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程事件消息查询Input
    /// </summary>
    public  class ProcessEventMessageQueryInput
    {
        /// <summary>
        /// 【选填项】流程定义Id
        /// </summary>
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【选填项】流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【选填项】流程事件名称
        /// </summary>
        public string ProcessEventName { get; set; }

        /// <summary>
        /// 【选填项】用户帐号（员工工号）
        /// </summary>
        public string UserCode { get; set; }

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
