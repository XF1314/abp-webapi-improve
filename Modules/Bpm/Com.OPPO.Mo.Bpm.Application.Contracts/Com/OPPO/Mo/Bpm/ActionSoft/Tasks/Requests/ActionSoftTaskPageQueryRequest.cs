using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft任务分页查询Request
    /// </summary>
    public class ActionSoftTaskPageQueryRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftTaskPageQueryRequest"/>
        /// </summary>
        public ActionSoftTaskPageQueryRequest() : base(ActionSoftTaskCommands.TaskPageQuery)
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

        /// <summary>
        /// 【选填项】首记录
        /// </summary>
        [JsonProperty("firstRow")]
        public int Offset { get; set; }

        /// <summary>
        /// 【选填项】记录条数
        /// </summary>
        [JsonProperty("rowCount")]
        public int Count { get; set; }
    }

}
