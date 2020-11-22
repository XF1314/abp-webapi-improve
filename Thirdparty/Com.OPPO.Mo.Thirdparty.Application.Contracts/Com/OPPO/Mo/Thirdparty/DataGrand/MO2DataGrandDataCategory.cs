using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// Mo上报到达观搜索的数据种类
    /// </summary>
    public enum MO2DataGrandDataCategory
    {
        /// <summary>
        ///  全部
        /// </summary>
        [Display(Name = "全部")]
        all = 0,

        /// <summary>
        ///  模块（流程/功能）
        /// </summary>
        [Display(Name = "模块")]
        module = 1,

        /// <summary>
        /// 便签
        /// </summary>
        [Display(Name = "便签")]
        mail = 2,

        /// <summary>
        /// 发文
        /// </summary>
        [Display(Name = "发文")]
        form = 3,

        ///// <summary>
        ///// 提示词
        ///// </summary>
        //[Display(Name = "提示词")]
        //suggestion = 4
    }
}
