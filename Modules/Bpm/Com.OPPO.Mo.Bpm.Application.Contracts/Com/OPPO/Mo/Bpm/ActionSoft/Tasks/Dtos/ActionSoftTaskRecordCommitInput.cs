using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft任务记录提交Input
    /// </summary>
    public class ActionSoftTaskRecordCommitInput
    {
        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】审批人账号，如果该账号与任务的认领人帐号不同，被记录为代理人操作
        /// </summary>
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 【选填项】审批动作<see cref="ActionSoftApprovalAction"/>，通常是审核菜单名称，如果不传入，审批记录该部分会显示“-”
        /// </summary>
        public ActionSoftApprovalAction Action { get; set; }

        /// <summary>
        /// 【选填项】留言
        /// </summary>
        public string Commment { get; set; }

        /// <summary>
        /// 【必填项】是否忽略节点设置的不显示审核菜单选项
        /// </summary>
        public bool IsIgnoreDefaultSetting { get; set; } = true;
    }
}
