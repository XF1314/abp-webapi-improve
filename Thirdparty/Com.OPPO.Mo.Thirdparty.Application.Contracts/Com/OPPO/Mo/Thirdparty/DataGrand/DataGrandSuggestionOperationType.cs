using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索提示词操作类型
    /// </summary>
    public enum DataGrandSuggestionOperationType
    {
        /// <summary>
        /// 新增提示词
        /// </summary>
        [Display(Name = "新增")]
        add = 1,

        ///// <summary>
        ///// 更新提示词
        ///// </summary>
        //[Display(Name = "更新")]
        //update = 2,

        /// <summary>
        /// 删除提示词
        /// </summary>
        [Display(Name = "删除")]
        delete = 3,

        /// <summary>
        /// 删除所有提示词
        /// </summary>
        [Display(Name = "删除所有")]
        refresh_all = 4,

        /// <summary>
        /// 删除所有用户私有的提示词
        /// </summary>
        [Display(Name = "删除所有私有")]
        refresh_private = 5,

        /// <summary>
        /// 删除所有公共的提示词
        /// </summary>
        [Display(Name = "删除所有公共")]
        refresh_public =6
    }
}
