using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks
{
    /// <summary>
    /// ActionSoft任务状态（系统），待进一步明确
    /// </summary>
    public enum ActionSoftTaskControlState
    {
        /// <summary>
        /// 补偿
        /// </summary>
        [Description("补偿")]
        compensate,

        /// <summary>
        /// 消息
        /// </summary>
        [Description("消息")]
        message,

        /// <summary>
        /// 信号
        /// </summary>
        [Description("信号")]
        signal,

        /// <summary>
        /// 时间
        /// </summary>
        [Description("时间")]
        timer,

        /// <summary>
        /// 取消【历史】
        /// </summary>
        [Description("取消")]
        cancel,

        /// <summary>
        /// 完成【历史】
        /// </summary>
        [Description("完成")]
        complete,

        /// <summary>
        /// 删除【历史】
        /// </summary>
        [Description("删除")]
        delete,

        /// <summary>
        /// 活动
        /// </summary>
        [Description("活动")]
        active,

        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        error,

        /// <summary>
        /// 挂起【历史】
        /// </summary>
        [Description("挂起")]
        suspend,

        /// <summary>
        /// 终止【历史】
        /// </summary>
        [Description("终止")]
        terminate,
    }
}
