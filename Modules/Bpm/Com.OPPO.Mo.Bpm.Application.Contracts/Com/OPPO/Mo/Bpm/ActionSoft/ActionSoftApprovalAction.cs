using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft审批动作
    /// </summary>
    public enum ActionSoftApprovalAction
    {
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        其他 = 0,

        /// <summary>
        /// 送审
        /// </summary>
        [Description("送审")]
        送审 = 1,

        /// <summary>
        /// 同意
        /// </summary>
        [Description("同意")]
        同意 = 2,

        /// <summary>
        /// 驳回
        /// </summary>
        [Description("驳回")]
        驳回 = 3,

        /// <summary>
        /// 特事特办
        /// </summary>
        [Description("特事特办")]
        特事特办 = 4,

       /// <summary>
       /// 收回（拟制人和审批人都可以操作，但只限于下一节点审批人未操作时，可以收回自己的审批操作）
       /// </summary>
        [Description("收回")]
        收回 = 5,

        /// <summary>
        /// 撤销（拟制人操作，可撤回任意审批中的流程）
        /// </summary>
        [Description("撤销重办")]
        撤销重办 = 6,

        /// <summary>
        /// 转办
        /// </summary>
        [Description("转办")]
        转办 = 7,

        /// <summary>
        /// 激活
        /// </summary>
        [Description("激活")]
        激活 = 8,

        /// <summary>
        /// 传阅
        /// </summary>
        [Description("传阅")]
        传阅 = 9,

        /// <summary>
        /// 跳过
        /// </summary>
        [Description("跳过")]
        跳过 = 10

    }
}
