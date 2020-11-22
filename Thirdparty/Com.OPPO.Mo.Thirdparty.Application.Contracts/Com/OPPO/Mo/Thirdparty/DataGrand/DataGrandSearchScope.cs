using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索范围
    /// </summary>
    public enum DataGrandSearchScope
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 标题
        /// </summary>
        [Description("标题")]
        Title = 1,

        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        Description = 3,
    }
}
