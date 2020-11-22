using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// 检查ActionSoft流程是否已结束
    /// </summary>
    public class ActionSoftProcessEndCheckRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessEndCheckRequest"/>
        /// </summary>
        public ActionSoftProcessEndCheckRequest() : base(ActionSoftProcessCommands.ProcessGet)
        {

        }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }
    }
}
