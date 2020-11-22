using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    ///  ActionSoft流程变量批量设置Input
    /// </summary>
    public class ActionSoftProcessVarBatchSetInput
    {
        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】流程变量s
        /// </summary>
        [JsonRequired]
        public Dictionary<string, string> ProcessVars { get; set; }
    }
}
