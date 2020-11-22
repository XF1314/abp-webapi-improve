using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// ActionSoft流程变量设置Input
    /// </summary>
    public class ActionSoftSpecifiedProcessVarSetInput
    {
        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】流程变量名称
        /// </summary>
        [JsonRequired]
        public string ProcessVarName { get; set; }

        /// <summary>
        /// 【必填项】流程变量值
        /// </summary>
        [JsonRequired]
        public string ProcessVarValue { get; set; }
    }
}
