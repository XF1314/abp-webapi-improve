using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程删除Request
    /// </summary>
    public  class ActionSoftProcessDeleteRequest:BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessDeleteRequest"/>
        /// </summary>
        public ActionSoftProcessDeleteRequest() : base(ActionSoftProcessCommands.ProcessDelete)
        { 
        
        }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonRequired]
        [JsonProperty("uid")]
        public string OperatorUserCode { get; set; }

        ///// <summary>
        ///// 删除原因
        ///// </summary>
        //public string DeleteReason { get; set; }
    }
}
