using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos
{

    public class ErpInventoryInfoDto
    {
        /// <summary>
        /// 库位
        /// </summary>
        [JsonProperty("inventory_name")]
        public string InventoryName { get; set; }

        /// <summary>
        /// 储位
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("organization_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 组织id
        /// </summary>
        [JsonProperty("organization_id")]
        public string organization_id { get; set; }

        /// <summary>
        /// 上次更新日期
        /// </summary>
        [JsonProperty("last_update_date")]
        public DateTime LastUpdateDate { get; set; }

        /// <summary>
        /// 代理备件退回抛ERP时,只能选择该值为2的库位
        /// </summary>
        [JsonProperty("availability_type")]
        public int AvailabilityType { get; set; }
    }
}
