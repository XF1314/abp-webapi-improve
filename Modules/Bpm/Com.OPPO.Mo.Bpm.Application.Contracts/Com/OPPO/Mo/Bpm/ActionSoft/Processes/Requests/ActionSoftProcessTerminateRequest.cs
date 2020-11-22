using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程终止/作废Request
    /// </summary>
    public class ActionSoftProcessTerminateRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessTerminateRequest"/>
        /// </summary>
        public ActionSoftProcessTerminateRequest() : base(ActionSoftProcessCommands.ProcessTerminate)
        {

        }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        ///// <summary>
        ///// 【必填项】终止/作废原因
        ///// </summary>
        //[JsonRequired]
        //public string TerminateReason { get; set; }

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonRequired]
        [JsonProperty("uid")]
        public string OperatorUserCode { get; set; }
    }
}
