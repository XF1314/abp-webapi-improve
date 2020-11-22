using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Requests
{
    /// <summary>
    /// ActionSoft流程定义获取Request
    /// </summary>
    public  class ActionSoftProcessDefinitionGetRequest:BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessDefinitionGetRequest"/>
        /// </summary>
        public ActionSoftProcessDefinitionGetRequest() : base(ActionSoftMetadataCommands.ProcessDefinitionGet)
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
