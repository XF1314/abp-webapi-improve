using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks
{
    /// <summary>
    /// ActionSoft任务认领类型
    /// </summary>
    public enum ActionSoftTaskClaimType
    {
        /// <summary>
        /// 人
        /// </summary>
        [Description("人")]
        User,

        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        Department,

        /// <summary>
        /// 角色
        /// </summary>
        [Description("角色")]
        Role,

        /// <summary>
        /// 群组
        /// </summary>
        [Description("群组")]
        Team
    }
}
