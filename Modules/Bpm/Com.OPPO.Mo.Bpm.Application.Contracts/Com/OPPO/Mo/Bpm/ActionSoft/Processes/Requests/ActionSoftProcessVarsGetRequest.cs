using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程变量获取Request
    /// </summary>
    public class ActionSoftProcessVarsGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessVarsGetRequest"/>
        /// </summary>
        public ActionSoftProcessVarsGetRequest() : base(ActionSoftProcessCommands.ProcessVarsGet)
        {

        }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

    }
}
