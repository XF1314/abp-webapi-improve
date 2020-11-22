using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 发文用户类型
    /// </summary>
    public enum ArticleUserType
    {
        /// <summary>
        /// 拟制人
        /// </summary>
        [Display(Name = "拟制人")]
        Drafter = 1,

        /// <summary>
        /// 流程修改人
        /// </summary>
        [Display(Name = "流程修改人")]
        Alter = 2,

        /// <summary>
        /// 流程审批人
        /// </summary>
        [Display(Name = "流程审批人")]
        Process = 3,

        /// <summary>
        /// 当前审批人
        /// </summary>
        [Display(Name = "当前审批人")]
        Current = 4,

        /// <summary>
        /// 读者
        /// </summary>
        [Display(Name = "读者")]
        Reader = 5
    }

    /// <summary>
    /// 用户或群组类型
    /// </summary>
    public enum UserOrGroupType
    {
        /// <summary>
        /// 用户
        /// </summary>
        [Display(Name = "用户")]
        User = 1,

        /// <summary>
        /// 组织
        /// </summary>
        [Display(Name = "组织")]
        Org = 2,

        /// <summary>
        /// 系统群组
        /// </summary>
        [Display(Name = "系统群组")]
        SystemGroup = 4,

        /// <summary>
        /// 个人群组
        /// </summary>
        [Display(Name = "个人群组")]
        PersonGroup = 7
    }
}
