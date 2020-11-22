using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    ///  ActionSoft流程删除Input
    /// </summary>
    public class ActionSoftProcessDeleteInput
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
        /// 【必填项】删除原因
        /// </summary>
        [JsonRequired]
        public string DeleteReason { get; set; }
    }
}
