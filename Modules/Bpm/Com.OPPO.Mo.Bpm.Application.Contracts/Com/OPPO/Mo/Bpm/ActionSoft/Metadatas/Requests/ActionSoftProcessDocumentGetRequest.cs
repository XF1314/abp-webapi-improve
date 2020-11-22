using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Requests
{
    /// <summary>
    /// ActionSoft流程说明获取Request
    /// </summary>
    public  class ActionSoftProcessDocumentGetRequest:BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessDocumentGetRequest"/>
        /// </summary>
        public ActionSoftProcessDocumentGetRequest() : base(ActionSoftMetadataCommands.ProcessDocumentGet)
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
