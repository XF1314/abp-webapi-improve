using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// ActionSoft流程提交(送审)Input
    /// </summary>
    public class ActionSoftProcessSubmitInput
    {
        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonRequired]
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 【选填项】流程变量s
        /// </summary>
        public Dictionary<string, string> ProcessVars { get; set; }


    }
}
