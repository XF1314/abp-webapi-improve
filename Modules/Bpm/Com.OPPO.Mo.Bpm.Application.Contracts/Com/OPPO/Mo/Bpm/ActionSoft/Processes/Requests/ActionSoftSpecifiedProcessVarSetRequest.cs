using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程变量设置Request
    /// </summary>
    public class ActionSoftSpecifiedProcessVarSetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftSpecifiedProcessVarSetRequest"/>
        /// </summary>
        public ActionSoftSpecifiedProcessVarSetRequest() : base(ActionSoftProcessCommands.SpecifiedProcessVarSet)
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

        /// <summary>
        /// 【必填项】流程变量值
        /// </summary>
        [JsonRequired]
        [JsonProperty("varValue")]
        public string ProcessVarValue { get; set; }

    }
}
