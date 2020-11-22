using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes
{
    /// <summary>
    /// ActionSoft流程状态（业务），可能存在空值
    /// </summary>
    public enum ActionSoftProcessState
    {
        /// <summary>
        /// 草稿，对应<see cref="ActionSoftProcessControlState.active"/>
        /// </summary>
        [Description("草稿")]
        draft,

        /// <summary>
        /// 审批中,对应<see cref="ActionSoftProcessControlState.active"/>
        /// </summary>
        [Description("审批中")]
        active,

        /// <summary>
        /// 已挂起，对应<see cref="ActionSoftProcessControlState.suspend"/>
        /// </summary>
        [Description("已挂起")]
        suspend,

        /// <summary>
        /// 已取消，对应<see cref="ActionSoftProcessControlState.cancel"/>
        /// </summary>
        [Description("已取消")]
        cancel,

        /// <summary>
        /// 已驳回，对应<see cref="ActionSoftProcessControlState.active"/>
        /// </summary>
        [Description("已驳回")]
        reject,

        /// <summary>
        /// 终止,对应<see cref="ActionSoftProcessControlState.terminate"/>
        /// </summary>
        [Description("已终止")]
        terminate,

        /// <summary>
        /// 已结束，对应<see cref="ActionSoftProcessControlState.end"/>
        /// </summary>
        [Description("已结束")]
        end

    }
}
