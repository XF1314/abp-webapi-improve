using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程分页查询Request
    /// </summary>
    public class ActionSoftProcessPageQueryRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessPageQueryRequest"/>
        /// </summary>
        public ActionSoftProcessPageQueryRequest() : base(ActionSoftProcessCommands.ProcessPageQuery)
        {

        }

        /// <summary>
        /// <see cref="ActionSoftProcessQueryModel"/>
        /// </summary>
        [JsonIgnore]
        public ActionSoftProcessQueryModel ProcessQueryModel { get; set; }

        /// <summary>
        /// <see cref="ActionSoftProcessQueryModel"/>
        /// </summary>
        [JsonProperty("pqm")]
        public string processQueryModel => ProcessQueryModel is null ? "{}" : JsonConvert.SerializeObject(ProcessQueryModel);

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
