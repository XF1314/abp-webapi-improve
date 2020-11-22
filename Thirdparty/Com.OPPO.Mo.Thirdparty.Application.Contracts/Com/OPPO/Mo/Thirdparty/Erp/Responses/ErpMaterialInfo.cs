using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    public class ErpMaterialInfo
    {
        /// <summary>
        /// 物料代码
        /// </summary>
       [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("item_desc")] 
        public string ItemDesc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("uom")]
        public string Uom { get; set; }

        /// <summary>
        /// 物料大小类
        /// </summary>
        [JsonProperty("item_maj_catogory")]
        public string ItemMajCatogory { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("item_min_catogory")]
        public string ItemMinCatogory { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("asset_maj_catogory")]
        public string AssetMajCatogory { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("asset_mid_catogory")]
        public string AssetMidCatogory { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("asset_min_catogory")]
        public string AssetMinCatogory { get; set; }

        /// <summary>
        /// 子项类型
        /// </summary>
        [JsonProperty("item_type")]
        public int ItemType { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("hs_code")]
        public string HsCode { get; set; }

        /// <summary>
        /// ？数量
        /// </summary>
        [JsonProperty("lie_idle_qty")]
        public int LieIdleQty { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("item_us_desc")]
        public string ItemUsDesc { get; set; }
    }
}
