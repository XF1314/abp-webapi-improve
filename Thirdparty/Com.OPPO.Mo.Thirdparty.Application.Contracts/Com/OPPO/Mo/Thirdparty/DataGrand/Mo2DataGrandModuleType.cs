using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// Mo上报到达观搜索的模块类型
    /// </summary>
    public enum MO2DataGrandModuleType
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Display(Name = "所有")]
        all = 0,

        /// <summary>
        /// 流程
        /// </summary>
        [Display(Name = "流程")]
        process = 1,

        /// <summary>
        /// 功能
        /// </summary>
        [Display(Name = "功能")]
        function = 2,

        /// <summary>
        /// 扩展
        /// </summary>
        [Display(Name = "扩展")]
        extension =3,

    }
}
