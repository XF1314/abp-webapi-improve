using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 任务事件消息查询Input
    /// </summary>
    public class TaskEventMessageQueryInput
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
        /// 【选填项】任务定义Id
        /// </summary>
        public string TaskDefinitionId { get; set; }

        /// <summary>
        /// 【选填项】任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 【选填项】任务事件名称
        /// </summary>
        public string TaskEventName { get; set; }

        /// <summary>
        /// 【选填项】操作用户帐号（员工工号）
        /// </summary>
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 【选填项】认领用户帐号（员工工号）
        /// </summary>
        public string TargetUserCode { get; set; }

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
