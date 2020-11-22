using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索提示词类型
    /// </summary>
    public enum DataGrandSuggestionPermissionType
    {
       ///// <summary>
       ///// 全部
       ///// </summary>
       // [Display(Name = "全部")]
       // all = 0,

        /// <summary>
        /// 公有
        /// </summary>
        [Display(Name = "公有")]
        @public = 1,

        /// <summary>
        /// 私有
        /// </summary>
        [Display(Name = "私有")]
        @private = 2

    }
}
