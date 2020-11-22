using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft 任务查询Request
    /// </summary>
    public class ActionSoftTaskQueryRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftTaskQueryRequest"/>
        /// </summary>
        public ActionSoftTaskQueryRequest() : base(ActionSoftTaskCommands.TaskQuery)
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
        private string taskQueryModel => TaskQueryModel is null?"{}": JsonConvert.SerializeObject(TaskQueryModel);
    }
}
