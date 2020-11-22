using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程取消Request
    /// </summary>
    public class ActionSoftProcessCancelRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessCancelRequest"/>
        /// </summary>
        public ActionSoftProcessCancelRequest() : base(ActionSoftProcessCommands.ProcessCancel)
        { }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        ///// <summary>
        ///// 【必填项】取消原因
        ///// </summary>
        //[JsonRequired]
        //public string CancelReason { get; set; }

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonRequired]
        [JsonProperty("uid")]
        public string OperatorUserCode { get; set; }
    }
}
