using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Etos
{
    /// <summary>
    /// 目标用户信息Eto
    /// </summary>
    public  class TargetUserInfoEto
    {
        /// <summary>
        /// 用户帐号（员工工号）
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 用户中文名字
        /// </summary>
        public string UserCnName { get; set; }

        /// <summary>
        /// 用户英文名字
        /// </summary>
        public string UserEnName { get; set; }

        /// <summary>
        /// 用户所属部门
        /// </summary>
        public string UserDepartment { get; set; }
    }
}
