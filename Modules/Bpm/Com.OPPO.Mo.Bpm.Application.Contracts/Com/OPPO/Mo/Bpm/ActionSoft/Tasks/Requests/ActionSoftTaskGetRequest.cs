using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft任务获取Request
    /// </summary>
    public  class ActionSoftTaskGetRequest:BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftTaskGetRequest"/>
        /// </summary>
        public ActionSoftTaskGetRequest() : base(ActionSoftTaskCommands.TaskGet)
        { 
        
        }

        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }
    }
}
