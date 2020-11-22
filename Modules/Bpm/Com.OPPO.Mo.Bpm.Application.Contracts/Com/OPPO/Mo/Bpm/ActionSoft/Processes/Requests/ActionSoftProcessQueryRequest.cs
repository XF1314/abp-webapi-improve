using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程查询Request
    /// </summary>
    public class ActionSoftProcessQueryRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessQueryRequest"/>
        /// </summary>
        public ActionSoftProcessQueryRequest() : base(ActionSoftProcessCommands.ProcessQuery)
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


    }
}
