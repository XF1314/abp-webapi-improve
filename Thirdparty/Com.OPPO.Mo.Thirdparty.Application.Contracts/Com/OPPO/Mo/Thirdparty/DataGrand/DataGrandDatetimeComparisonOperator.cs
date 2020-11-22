using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索时间比较符
    /// </summary>
    public enum DataGrandDatetimeComparisonOperator
    {
        ///// <summary>
        ///// 大于
        ///// </summary>
        //[Display(Name = "大于")]
        //Greater = 1,

        /// <summary>
        /// 大于或等于
        /// </summary>
        [Display(Name = "大于或等于")]
        GreaterOrEqual = 2,

        ///// <summary>
        ///// 小于
        ///// </summary>
        //[Display(Name = "小于")]
        //Less = 3,

        /// <summary>
        /// 小于或等于
        /// </summary>
        [Display(Name = "小于或等于")]
        LessOrEqual = 4,

        ///// <summary>
        ///// 等于
        ///// </summary>
        //[Display(Name = "等于")]
        //Equal = 5
    }
}
