using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程撤回Request
    /// </summary>
    public  class ActionSoftProcessRevokeRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessRevokeRequest"/>
        /// </summary>
        public ActionSoftProcessRevokeRequest() : base(ActionSoftProcessCommands.ProcessRestart)
        { 
        }

        /// <summary>
        /// 流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 撤回原因
        /// </summary>
        [JsonRequired]
        [JsonProperty("restartReason")]
        public string RevokeReason { get; set; }

        ///// <summary>
        ///// 操作人工号
        ///// </summary>
        //public string OperatorUserCode { get; set; }

    }
}
