using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft指定节点任务参与者获取Request
    /// </summary>
    public class ActionSoftTaskParticipantsGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftTaskParticipantsGetRequest"/>
        /// </summary>
        public ActionSoftTaskParticipantsGetRequest() : base(ActionSoftTaskCommands.TaskParticipantsGet)
        {

        }

        /// <summary>
        /// 【必填项】用户工号
        /// </summary>
        [JsonProperty("uid")]
        public string UserCode { get; set; } = MoBpmConsts.ActionSoftAdminUserCode;

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        ///【必填项】 任务实例Id
        /// </summary>
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】下一个人工任务定义（要预测的任务节点）Id
        /// </summary>
        [JsonProperty("nextUserTaskDefId")]
        public string NextUserTaskActivityId { get; set; }

    }
}
