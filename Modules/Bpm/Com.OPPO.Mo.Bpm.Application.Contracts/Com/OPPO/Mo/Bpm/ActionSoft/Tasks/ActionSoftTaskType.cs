using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks
{
    /// <summary>
    /// ActionSoft任务类型
    /// </summary>
    public enum ActionSoftTaskType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = 0,

        /// <summary>
        /// 人工待办类任务
        /// </summary>
        [Description("人工待办类任务")]
        Transact = 1,

        /// <summary>
        /// 只读传阅类任务
        /// </summary>
        [Description("传阅类任务")]
        Circulate = 2,

        /// <summary>
        /// 等待类任务
        /// </summary>
        [Description("等待任务")]
        Wait = 4,

        /// <summary>
        /// 系统通知类任务
        /// </summary>
        [Description("系统通知类任务")]
        SystemNotity = 9,

        /// <summary>
        /// 动态任务，如加签、协作
        /// </summary>
        [Description("动态任务")]
        Addhoc = 11

    }
}
