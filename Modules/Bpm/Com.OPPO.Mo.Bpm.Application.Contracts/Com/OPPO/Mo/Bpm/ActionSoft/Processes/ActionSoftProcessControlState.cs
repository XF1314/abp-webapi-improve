using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes
{
    /// <summary>
    /// ActionSoft流程状态（系统）,待进一步明确
    /// </summary>
    public enum ActionSoftProcessControlState
    {
        /// <summary>
        /// 活动（流程创建成功后就会是该状态）
        /// </summary>
        [Description("活动")]
        active,

        /// <summary>
        /// 取消
        /// </summary>
        [Description("取消")]
        cancel,

        /// <summary>
        /// 挂起
        /// </summary>
        [Description("挂起")]
        suspend,

        /// <summary>
        /// 已结束
        /// </summary>
        [Description("结束")]
        end,

        /// <summary>
        /// 终止
        /// </summary>
        [Description("终止")]
        terminate
    }
}
