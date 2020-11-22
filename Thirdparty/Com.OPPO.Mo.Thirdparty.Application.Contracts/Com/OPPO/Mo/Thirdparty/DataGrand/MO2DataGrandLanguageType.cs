using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
   /// <summary>
   /// MO上报到达观搜索的语言类型
   /// </summary>
    public enum MO2DataGrandLanguageType
    {
        /// <summary>
        /// 缺省
        /// </summary>
        [Display(Name ="缺省")]
        Default = 0,

        /// <summary>
        /// 中文
        /// </summary>
        [Display(Name = "中文")]
        Chinese =1,

        /// <summary>
        /// 英文
        /// </summary>
        [Display(Name = "英文")]
        English =2

    }
}
