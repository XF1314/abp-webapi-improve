using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Requests
{
    /// <summary>
    /// ActionSoft流程主版本（正在运行的版本）Id获取Request
    /// </summary>
    public class ActionSoftProcessMainVersionIdGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessMainVersionIdGetRequest"/>
        /// </summary>
        public ActionSoftProcessMainVersionIdGetRequest() : base(ActionSoftMetadataCommands.ProcessMainVersionIdGet)
        {

        }

        /// <summary>
        /// 【必填项】流程定义Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processDefId")]
        public string ProcessDefinitionId { get; set; }
    }
}
