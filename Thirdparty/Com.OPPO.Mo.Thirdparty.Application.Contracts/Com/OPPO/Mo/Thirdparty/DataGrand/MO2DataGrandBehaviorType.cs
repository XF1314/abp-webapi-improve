using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// MO上报到达观搜索的用户行为类型
    /// </summary>
    public enum MO2DataGrandBehaviorType
    {
        /// <summary>
        /// 搜索
        /// </summary>
        [Display(Name ="搜索")]
        search=0,

        /// <summary>
        /// 搜索点击
        /// </summary>
        [Display(Name ="搜索点击")]
        search_click=1,

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        sort = 2
    }
}
