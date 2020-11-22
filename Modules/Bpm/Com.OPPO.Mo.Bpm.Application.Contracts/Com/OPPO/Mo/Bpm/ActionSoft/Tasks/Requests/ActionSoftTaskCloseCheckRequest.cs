using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft任务结束检查
    /// </summary>
    public  class ActionSoftTaskCloseCheckRequest:BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftTaskCloseCheckRequest"/>
        /// </summary>
        public ActionSoftTaskCloseCheckRequest() : base(ActionSoftTaskCommands.TaskCloseCheck)
        { 
        
        }

        /// <summary>
        ///  【必填项】任务实例Id
        /// </summary>
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }
    }
}
