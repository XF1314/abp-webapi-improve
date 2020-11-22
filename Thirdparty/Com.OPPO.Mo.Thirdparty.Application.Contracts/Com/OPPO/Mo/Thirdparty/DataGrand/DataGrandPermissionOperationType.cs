using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索权限操作类型
    /// </summary>
    public enum DataGrandPermissionOperationType
    {
        /// <summary>
        /// 新增或更新
        /// </summary>
        [Display(Name = "新增或更新")]
        add = 1,

        /// <summary>
        /// 删除
        /// </summary>
        [Display(Name = "删除")]
        delete = 3
    }
}
