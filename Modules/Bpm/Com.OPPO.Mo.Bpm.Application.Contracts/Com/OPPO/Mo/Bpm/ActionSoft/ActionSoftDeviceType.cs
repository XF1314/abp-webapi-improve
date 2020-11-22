using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft设备类型
    /// </summary>
    public enum ActionSoftDeviceType
    {
        /// <summary>
        /// Pc
        /// </summary>
        [Description("Pc")]
        pc,

        /// <summary>
        /// 移动端
        /// </summary>
        [Description("Mobile")]
        mobile,

        /// <summary>
        /// Web端
        /// </summary>
        [Description("Web")]
        web
    }
}
