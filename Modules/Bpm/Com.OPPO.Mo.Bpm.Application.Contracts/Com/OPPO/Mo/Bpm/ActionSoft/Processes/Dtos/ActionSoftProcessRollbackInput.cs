using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    public class ActionSoftProcessRollbackInput
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        [JsonRequired]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 目标节点Id（TaskDefinitionId）,必须是一个历史处理过的路径
        /// </summary>
        [JsonRequired]
        public string TargetActivityId { get; set; }

        /// <summary>
        /// 操作人工号
        /// </summary>
        [JsonRequired]
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 回退原因
        /// </summary>
        [JsonRequired]
        public string RollbackReason { get; set; }


        /// <summary>
        /// 是否执行补偿事件
        /// </summary>
        public bool IsCompensation { get; set; } = true;
    }
}
