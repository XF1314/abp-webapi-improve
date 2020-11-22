using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft任务传阅创建Request
    /// </summary>
    public class ActionSoftCirculationTaskCreateRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftCirculationTaskCreateRequest"/>
        /// </summary>
        public ActionSoftCirculationTaskCreateRequest() : base(ActionSoftTaskCommands.CirculationTaskCreate)
        {

        }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】父任务实例Id，传阅任务由该任务创建
        /// </summary>
        [JsonProperty("parentTaskInstId")]
        public string ParentTaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】任务标题
        /// </summary>
        [JsonProperty("title")]
        public string TaskTitle { get; set; }

        /// <summary>
        /// 【必填项】待阅人工号s
        /// </summary>
        [JsonIgnore]
        public List<string> ClaimUserCodes { get; set; }

        /// <summary>
        /// 【必填项】待阅人工号s,,一个或多（多个用空格隔开）
        /// </summary>
        [JsonProperty("participant")]
        private string claimUserCodes => string.Join(" ", ClaimUserCodes);

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonProperty("uid")]
        public string OperatorUserCode { get; set; }

    }
}
