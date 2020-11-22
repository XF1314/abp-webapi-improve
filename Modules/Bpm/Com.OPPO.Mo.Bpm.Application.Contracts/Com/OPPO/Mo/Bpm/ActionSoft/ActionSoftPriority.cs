using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft优先级，其中：（0-低；1-普通；2-中；3-高）默认为1
    /// </summary>
    public enum ActionSoftPriority
    {
        /// <summary>
        /// 低
        /// </summary>
        [Description("低")]
        low = 0,

        /// <summary>
        /// 普通
        /// </summary>
        [Description("普通")]
        general = 1,

        /// <summary>
        /// 中
        /// </summary>
        [Description("中")]
        medium = 2,

        /// <summary>
        /// 高
        /// </summary>
        [Description("高")]
        high = 3

    }
}
