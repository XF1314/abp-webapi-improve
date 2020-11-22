using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程实例可撤回性检查Input
    /// </summary>
    public class ActionSoftProcessRevocabilityCheckRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessRevocabilityCheckRequest"/>
        /// </summary>
        public ActionSoftProcessRevocabilityCheckRequest() : base(ActionSoftProcessCommands.ProcessRestartCheck)
        {

        }

        /// <summary>
        /// 流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }
    }
}
