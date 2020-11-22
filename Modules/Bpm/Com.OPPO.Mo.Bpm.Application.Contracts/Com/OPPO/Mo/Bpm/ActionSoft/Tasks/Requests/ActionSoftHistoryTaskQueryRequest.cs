using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft历史任务查询Request
    /// </summary>
    public  class ActionSoftHistoryTaskQueryRequest:BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftHistoryTaskQueryRequest"/>
        /// </summary>
        public ActionSoftHistoryTaskQueryRequest() : base(ActionSoftTaskCommands.HistoryTaskQuery)
        { 
        
        }

        /// <summary>
        /// <see cref="ActionSoftTaskQueryModel"/>
        /// </summary>
        [JsonIgnore]
        public ActionSoftTaskQueryModel TaskQueryModel { get; set; }

        /// <summary>
        /// <see cref="ActionSoftTaskQueryModel"/>
        /// </summary>
        [JsonProperty("tqm")]
        private string taskQueryModel => TaskQueryModel is null ? "{}" : JsonConvert.SerializeObject(TaskQueryModel);
    }
}
