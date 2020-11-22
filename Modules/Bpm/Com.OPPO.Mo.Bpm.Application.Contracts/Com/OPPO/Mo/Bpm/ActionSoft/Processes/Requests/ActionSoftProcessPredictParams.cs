using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程预测参数s
    /// </summary>
    public class ActionSoftProcessPredictParams
    {
        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】会话标识
        /// </summary>
        [JsonProperty("sid")]
        public string SessionId { get; set; }
    }
}
