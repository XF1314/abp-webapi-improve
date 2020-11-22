using Com.OPPO.Mo.Bpm.ActionSoft.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Requests
{
    /// <summary>
    /// ActionSoft流程跟踪Url获取Request
    /// </summary>
    public class ActionSoftProcessTrackingUrlGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessTrackingUrlGetRequest"/>
        /// </summary>
        public ActionSoftProcessTrackingUrlGetRequest() : base(ActionSoftMetadataCommands.ProcessTrackingUrlGet)
        {
        }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】会话Id<see cref="ActionSoftExtensionCommands.SessionIdGet"/>
        /// </summary>
        [JsonRequired]
        [JsonProperty("sid")]
        public string SessionId { get; set; }
    }
}
