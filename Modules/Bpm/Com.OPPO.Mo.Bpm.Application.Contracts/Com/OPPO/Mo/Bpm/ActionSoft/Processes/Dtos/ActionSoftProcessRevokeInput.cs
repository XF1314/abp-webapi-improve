using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// ActionSoft流程撤回Input
    /// </summary>
    public class ActionSoftProcessRevokeInput
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 操作人工号
        /// </summary>
        [JsonRequired]
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 撤回原因
        /// </summary>
        [JsonRequired]
        public string RevokeReason { get; set; }
    }
}
