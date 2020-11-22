using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft任务完成Request
    /// </summary>
    public class ActionSoftTaskCompleteRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftTaskCompleteRequest"/>
        /// </summary>
        public ActionSoftTaskCompleteRequest() : base(ActionSoftTaskCommands.TaskComplete)
        {
            ProcessVars = new Dictionary<string, string>();
        }

        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonRequired]
        [JsonProperty("uid")]
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 【选填项】流程变量s
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> ProcessVars { get; set; }

        /// <summary>
        /// 【选填项】流程变量s
        /// </summary>
        [JsonProperty("vars")]
        private string processVars => JsonConvert.SerializeObject(ProcessVars);

        /// <summary>
        /// 【选填项】如果评估可以达成向后推进的条件，是否继续自动向下执行，默认值为true。
        /// 如果开发者不希望干扰后继的路线的执行， 应提供true值，该选项对传阅、加签等非常规任务无效
        /// </summary>
        [JsonProperty("isBranch")]
        public bool IsContinue { get; set; } = true;

        /// <summary>
        /// 【选填项】是否遇到人工任务时暂停创建，继而由外部API根据用户选择执行人范围后再创建
        /// </summary>
        [JsonProperty("isBreakUserTask")]
        public bool IsPauseOnUserTask { get; set; } = false;


    }
}
