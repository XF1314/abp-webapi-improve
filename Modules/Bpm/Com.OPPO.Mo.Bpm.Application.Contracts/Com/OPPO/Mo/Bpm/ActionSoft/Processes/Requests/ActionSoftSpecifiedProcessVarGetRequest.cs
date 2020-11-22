using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft根据流程实例信息获取Request
    /// </summary>
    public class ActionSoftSpecifiedProcessIntanceVarGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftSpecifiedProcessIntanceVarGetRequest"/>
        /// </summary>
        public ActionSoftSpecifiedProcessIntanceVarGetRequest() : base(ActionSoftProcessCommands.SpecifiedProcessVarGet)
        {

        }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】流程变量名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("varName")]
        public string ProcessVarName { get; set; }
    }
}
