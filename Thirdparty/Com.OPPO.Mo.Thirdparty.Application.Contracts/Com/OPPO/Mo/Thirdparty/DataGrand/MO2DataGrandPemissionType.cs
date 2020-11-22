using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// MO上报到达观搜索的权限类型
    /// </summary>
    public enum MO2DataGrandPemissionType
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Display(Name = "所有")]
        All = 0,

        /// <summary>
        /// 用户编码
        /// </summary>
        [Display(Name = "用户编码")]
        UserCode = 1,

        /// <summary>
        /// 部门编码
        /// </summary>
        [Display(Name = "部门编码")]
        OrgnizaionCode = 2,

        /// <summary>
        /// 用户角色
        /// </summary>
        [Display(Name = "用户角色")]
        Role = 3
    }
}
