using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft分类类型，其中：（0-业务域分类；1-组织区域分类；2-系统分类，3-自定义分类）
    /// </summary>
    public enum ActionSoftClassifyType
    {
        /// <summary>
        /// 业务域分类，Instance Of Business Domain
        /// </summary>
        [Description("业务域分类")]
        IOBD = 0,

        /// <summary>
        /// 组织区域分类，Instance Of Regional
        /// </summary>
        [Description("组织区域分类")]
        IOR = 1,

        /// <summary>
        /// 系统分类，Instance Of System
        /// </summary>
        [Description("系统分类")]
        IOS = 2,

        /// <summary>
        /// 自定义分类，Instance Of Customize
        /// </summary>
        [Description("自定义分类")]
        IOC = 3
    }
}
