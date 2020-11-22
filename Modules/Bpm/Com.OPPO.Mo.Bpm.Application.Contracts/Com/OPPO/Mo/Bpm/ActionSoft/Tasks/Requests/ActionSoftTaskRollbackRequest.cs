using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft任务回退Request
    /// </summary>
    public class ActionSoftTaskRollbackRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftTaskRollbackRequest"/>
        /// </summary>
        public ActionSoftTaskRollbackRequest() : base(ActionSoftTaskCommands.TaskRollback)
        {

        }
        
        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】目标节点Id（TaskDefinitionId）,必须是一个历史处理过的路径
        /// </summary>
        [JsonRequired]
        [JsonProperty("targetActivityId")]
        public string TargetActivityId { get; set; }

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonRequired]
        [JsonProperty("uid")]
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 【选填项】是否执行补偿事件
        /// </summary>
        public bool IsCompensation { get; set; } = true;

        /// <summary>
        /// 【必填项】回退原因
        /// </summary>
        [JsonRequired]
        public string RollbackReason { get; set; }


    }
}
