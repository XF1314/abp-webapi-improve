using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Requests
{
    /// <summary>
    /// ActionSoft流程定义Id获取Request
    /// </summary>
    public class ActionSoftProcessDefinitionIdGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessDefinitionIdGetRequest"/>
        /// </summary>
        public ActionSoftProcessDefinitionIdGetRequest() : base(ActionSoftMetadataCommands.ProcessDefinitionIdGet)
        {

        }

        /// <summary>
        /// 【必填项】流程定义版本Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processVerId")]
        public string ProcessDefinitionVersionId { get; set; }
    }
}
