using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft任务模拟Request
    /// </summary>
    public class ActionSoftTaskSimulateRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftTaskSimulateRequest"/>
        /// </summary>
        public ActionSoftTaskSimulateRequest() : base(ActionSoftTaskCommands.TaskSimulate)
        {

        }

        /// <summary>
        /// 【必填项】合法工号
        /// </summary>
        [JsonProperty("uid")]
        public string UserCode { get; set; }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }
    }
}
