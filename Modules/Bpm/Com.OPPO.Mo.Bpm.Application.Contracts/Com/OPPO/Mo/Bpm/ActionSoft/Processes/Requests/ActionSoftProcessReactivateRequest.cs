using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程重新激活（重新激活已结束的流程）
    /// </summary>
    public class ActionSoftProcessReactivateRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessReactivateRequest"/>
        /// </summary>
        public ActionSoftProcessReactivateRequest() : base(ActionSoftProcessCommands.ProcessReactive)
        { }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】目标ActivityId
        /// </summary>
        [JsonRequired]
        public string TargetActivityId { get; set; }

        /// <summary>
        /// 【选填项】目标节点审批人，如果目标节点是人工任务，需指定任务的参与者
        /// </summary>
        [JsonRequired]
        [JsonProperty("targetUID")]
        public string ClaimToUserCode { get; set; }

        /// <summary>
        /// 【必填项】是否清空历史处理过程
        /// </summary>
        [JsonRequired]
        public bool IsClearHistory { get; set; } = false;

        /// <summary>
        /// 【必填项】流程实例重新激活的原因
        /// </summary>
        [JsonRequired]
        public string ReactivateReason { get; set; }

        /// <summary>
        /// 【必填项】操作者工号
        /// </summary>
        [JsonRequired]
        [JsonProperty("uid")]
        public string OperatorUserCode { get; set; }


    }
}
