using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程变量批量设置Request
    /// </summary>
    public class ActionSoftProcessVarBatchSetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessVarBatchSetRequest"/>
        /// </summary>
        public ActionSoftProcessVarBatchSetRequest() : base(ActionSoftProcessCommands.ProcessVarBatchSet)
        {
            ProcessVars = new Dictionary<string, string>();
        }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】流程变量s
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> ProcessVars { get; set; }

        /// <summary>
        /// 【必填项】流程变量s
        /// </summary>
        [JsonProperty("vars")]
        private string processVars => JsonConvert.SerializeObject(ProcessVars);
    }
}
