using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft任务状态，其中（0-未读；1-已读）
    /// </summary>
    public enum ActionSoftReadState
    {
        /// <summary>
        /// 未读
        /// </summary>
        [Description("未读")]
        unread = 0,

        /// <summary>
        /// 已读
        /// </summary>
        [Description("已读")]
        read = 1
    }
}
