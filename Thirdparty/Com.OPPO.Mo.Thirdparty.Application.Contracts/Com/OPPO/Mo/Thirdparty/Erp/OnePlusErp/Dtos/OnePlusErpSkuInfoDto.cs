using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// OnePlus Erp 
    /// </summary>
    public class OnePlusErpSkuInfoDto
    {
        /// <summary>
        /// Sku代码
        /// </summary>
        [JsonProperty("SKU")]
        public string Sku { get; set; }
        /// <summary>
        /// UOM
        /// </summary>
        [JsonProperty("UOM")]
        public string Primary_Uom_Code { get; set; }
        /// <summary>
        /// Sku中文描述
        /// </summary>
        [JsonProperty("SKU_DESC")]
        public string Sku_Desc { get; set; }
        /// <summary>
        /// Sku英文描述
        /// </summary>
        [JsonProperty("SKU_DESC_US")]
        public string Sku_Desc_Us { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty("CATEGORY_ID")]
        public string Category_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("FIRST_CATE")]
        public string First_Cate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("SECOND_CATE")]
        public string Second_Cate { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("DESCRIPTION")]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("MO_CATE")]
        public string Mo_Cate { get; set; }
    }
}
