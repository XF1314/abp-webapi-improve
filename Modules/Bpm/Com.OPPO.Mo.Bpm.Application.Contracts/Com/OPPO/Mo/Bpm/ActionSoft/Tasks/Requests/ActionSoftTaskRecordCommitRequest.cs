using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft任务记录提交Request
    /// </summary>
    public class ActionSoftTaskRecordCommitRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftTaskRecordCommitRequest"/>
        /// </summary>
        public ActionSoftTaskRecordCommitRequest() : base(ActionSoftTaskCommands.TaskRecordCommit)
        { }

        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】操作人工号，如果该账号与任务的认领人工号不同，被记录为代理人操作
        /// </summary>
        [JsonRequired]
        [JsonProperty("user")]
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 【选填项】审批动作<see cref="ActionSoftApprovalAction"/>，通常是审核菜单名称，如果不传入，审批记录该部分会显示“-”
        /// </summary>
        [JsonProperty("actionName")]
        public string Action { get; set; }

        /// <summary>
        /// 【选填项】留言
        /// </summary>
        [JsonProperty("commentMsg")]
        public string Commment { get; set; }

        /// <summary>
        /// 【必填项】是否忽略节点设置的不显示审核菜单选项
        /// </summary>
        [JsonRequired]
        [JsonProperty("isIgnoreDefaultSetting")]
        public bool IsIgnoreDefaultSetting { get; set; } = true;
    }
}
