using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft完成任务并提交意见Input
    /// </summary>
    public class ActionSoftTaskCompleteWithRecordInput
    {
        /// <summary>
        /// <see cref="ActionSoftTaskCompleteInput"/>
        /// </summary>
        public ActionSoftTaskCompleteWithRecordInput()
        {
            ProcessVars = new Dictionary<string, string> { };
        }

        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        [JsonRequired]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonRequired]
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 【选填项】流程变量s
        /// </summary>
        public Dictionary<string, string> ProcessVars { get; set; }

        /// <summary>
        /// 【选填项】如果评估可以达成向后推进的条件，是否继续自动向下执行，默认值为true。
        /// 如果开发者不希望干扰后继的路线的执行， 应提供true值，该选项对传阅、加签等非常规任务无效
        /// </summary>
        public bool IsContinue { get; set; } = true;

        /// <summary>
        /// 【选填项】是否遇到人工任务时暂停创建，继而由外部API根据用户选择执行人范围后再创建
        /// </summary>
        public bool IsPauseOnUserTask { get; set; } = false;


        #region record
        /// <summary>
        /// 【选填项】审批动作<see cref="ActionSoftApprovalAction"/>，通常是审核菜单名称，如果不传入，审批记录该部分会显示“-”
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 【选填项】留言
        /// </summary>
        public string Commment { get; set; }

        /// <summary>
        /// 【必填项】是否忽略节点设置的不显示审核菜单选项
        /// </summary>
        public bool IsIgnoreDefaultSetting { get; set; } = true;

        #endregion
    }



}
