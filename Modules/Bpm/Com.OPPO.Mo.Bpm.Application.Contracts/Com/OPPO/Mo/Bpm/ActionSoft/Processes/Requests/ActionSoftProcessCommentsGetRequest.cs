using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程审批留言获取Request
    /// </summary>
    public class ActionSoftProcessCommentsGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessCommentsGetRequest"/>
        /// </summary>
        public ActionSoftProcessCommentsGetRequest() : base(ActionSoftProcessCommands.ProcessCommentsGet)
        {
        }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

    }
}
