using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Responses
{

    public class ErpInventoryInfo
    {
        /// <summary>
        /// 库位
        /// </summary>
        public string InventoryName { get; set; }
        /// <summary>
        /// 储位
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 组织id
        /// </summary>
        public string organization_id { get; set; }
        /// <summary>
        /// 上次更新日期
        /// </summary>
        public DateTime LastUpdateDate { get; set; }
        /// <summary>
        /// 代理备件退回抛ERP时,只能选择该值为2的库位
        /// </summary>
        public int AvailabilityType { get; set; }
    }


}
