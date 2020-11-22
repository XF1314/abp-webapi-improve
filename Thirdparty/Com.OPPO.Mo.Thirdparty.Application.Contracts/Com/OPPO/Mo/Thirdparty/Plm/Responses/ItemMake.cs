using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Responses
{
    public class ItemMake
    {
        /// <summary>
        /// 物料号
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 是否是制造件
        /// </summary>
        public string IsMakeOrBuy { get; set; }
    }
}
