using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft Eai任务完成Request
    /// </summary>
    public class ActionSoftEaiTaskCompleteRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftEaiTaskCompleteRequest"/>
        /// </summary>
        public ActionSoftEaiTaskCompleteRequest() : base(ActionSoftTaskCommands.EaiTaskComplete)
        {
        }

        /// <summary>
        /// 【必填项】Eai任务实例Id
        /// </summary>
        [JsonProperty("eaiTaskInstId")]
        public string EaiTaskInstanceId { get; set; }

    }
}
