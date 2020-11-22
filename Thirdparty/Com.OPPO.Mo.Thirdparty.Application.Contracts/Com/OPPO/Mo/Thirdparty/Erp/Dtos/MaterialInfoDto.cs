using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{

    public class MaterialInfoDto
    {
        /// <summary>
        /// 组织id
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// 类别id
        /// </summary>
        [JsonProperty("category_id")]
        public string CategoryId { get; set; }
        /// <summary>
        /// 组织code
        /// </summary>
        [JsonProperty("organization_code")]
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        [JsonProperty("item_code")]
        public string MaterialCode { get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        [JsonProperty("description")]
        public string MaterialDesc { get; set; }
        //[JsonProperty("item_us_desc")]
        //public string MaterialUsDesc { get; set; }
        /// <summary>
        /// 物料小类
        /// </summary>
        [JsonProperty("minor_category")]
        public string MinorCategory { get; set; }
        /// <summary>
        /// 物料大类
        /// </summary>
        //[JsonProperty("major_category")]
        //public string MajorCategory { get; set; }
        [JsonProperty("primary_uom_code")]
        public string PrimaryUomCode { get; set; }
        /// <summary>
        /// 物料类型
        /// </summary>
        [JsonProperty("item_type")]
        public string Type { get; set; }
        [JsonProperty("fixed_lot_multiplier")]
        public string FixedLotMultiplier { get; set; }
        [JsonProperty("status_code")]
        public string StatusCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_date")]
        public string CreateDate { get; set; }
        /// <summary>
        /// 上次更新日期
        /// </summary>
        [JsonProperty("last_update_date")]
        public string LastUpdateDate { get; set; }
        //[JsonProperty("stock_qty")]
        //public string StockQty { get; set; }
    }
}
