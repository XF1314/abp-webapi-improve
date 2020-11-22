using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Requests
{
    /// <summary>
    /// ActionSoft人工任务定义获取Request
    /// </summary>
    public class ActionSoftUserTaskDefinitionGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftUserTaskDefinitionGetRequest"/>
        /// </summary>
        public ActionSoftUserTaskDefinitionGetRequest() : base(ActionSoftMetadataCommands.UserTaskDefinitionGet)
        { 
        
        }

        /// <summary>
        /// 【必填项】流程定义Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processDefId")]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【必填项】人工任务定义Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("userTaskDefId")]
        public string UserTaskDefinitionId { get; set; }

    }
}
