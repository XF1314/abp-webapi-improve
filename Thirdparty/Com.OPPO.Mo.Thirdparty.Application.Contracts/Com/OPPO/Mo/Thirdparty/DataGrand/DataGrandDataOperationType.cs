using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索数据操作类型
    /// </summary>
    public enum DataGrandDataOperationType
    {
        /// <summary>
        /// 新增
        /// </summary>
        [Display(Name = "新增")]
        add = 1,

        /// <summary>
        /// 更新
        /// </summary>
        [Display(Name = "更新")]
        update = 2,

        /// <summary>
        /// 删除
        /// </summary>
        [Display(Name = "删除")]
        delete = 3
    }
    
}
