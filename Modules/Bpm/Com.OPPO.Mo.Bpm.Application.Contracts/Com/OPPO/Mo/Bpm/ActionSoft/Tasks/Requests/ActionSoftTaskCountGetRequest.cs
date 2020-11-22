using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft任务数量获取Request
    /// </summary>
    public class ActionSoftTaskCountGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftTaskCountGetRequest"/>
        /// </summary>
        public ActionSoftTaskCountGetRequest() : base(ActionSoftTaskCommands.TaskCountGet)
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
