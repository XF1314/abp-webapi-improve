using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程数量获取Request
    /// </summary>
    public class ActionSoftProcessCountGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessCountGetRequest"/>
        /// </summary>
        public ActionSoftProcessCountGetRequest() : base(ActionSoftProcessCommands.ProcessCountGet)
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
