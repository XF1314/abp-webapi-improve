using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft 任务传阅Input
    /// </summary>
    public class ActionSoftCirculationTaskCreateInput
    {
        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】任务实例Id，传阅任务由该任务创建
        /// </summary>
        public string ParentTaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】任务标题
        /// </summary>
        [JsonRequired]
        public string TaskTitle { get; set; }

        /// <summary>
        /// 【必填项】待阅人工号s
        /// </summary>
        [JsonRequired]
        public List<string> ClaimUserCodes { get; set; }

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonRequired]
        public string OperatorUserCode { get; set; }
    }
}
