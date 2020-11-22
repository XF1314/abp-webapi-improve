using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft历史任务获取Request
    /// </summary>
     public class ActionSoftHistoryTaskGetRequest:BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftHistoryTaskGetRequest"/>
        /// </summary>
        public ActionSoftHistoryTaskGetRequest() : base(ActionSoftTaskCommands.HistoryTaskGet)
        { 
        
        }

        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }
    }
}
