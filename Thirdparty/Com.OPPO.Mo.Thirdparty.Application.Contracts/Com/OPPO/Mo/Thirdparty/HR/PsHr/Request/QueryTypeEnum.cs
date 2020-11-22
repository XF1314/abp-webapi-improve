using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public enum QueryTypeEnum
    {
        /// <summary>
        /// 1表示只获取有角色的it系统
        /// </summary>
        QueryRole = 1,
        /// <summary>
        /// 2表示只获取有权限的it系统
        /// </summary>
        QueryPower = 2,
        /// <summary>
        /// 3表示获取全部
        /// </summary>
        QueryAll = 3
    }
}
