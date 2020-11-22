using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    /// <summary>
    /// 设备调拨输出类
    /// </summary>
    public class ErpInstanceInfo
    {
        /// <summary>
        /// 实例代码
        /// </summary>
        [JsonProperty("instance_code")]
        public string InstanceCode { get; set; }

        /// <summary>
        /// 资产编号
        /// </summary>
        [JsonProperty("asset_number")]
        public string AssetNumber { get; set; }

        /// <summary>
        /// 子项代码
        /// </summary>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 实例描述
        /// </summary>
        [JsonProperty("instance_desc")]
        public string InstanceDesc { get; set; }

        /// <summary>
        /// 字库编码
        /// </summary>
        [JsonProperty("subinv_code")]
        public string SubinvCode { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("locator_code")]
        public string LocatorCode { get; set; }

        /// <summary>
        /// 字库类型编码
        /// </summary>
        [JsonProperty("inv_category_code")]
        public string InvCategoryCode { get; set; }

        /// <summary>
        /// 子项类型
        /// </summary>
        [JsonProperty("item_type")]
        public string ItemType { get; set; }

        /// <summary>
        /// 子项分类
        /// </summary>
        [JsonProperty("item_category")]
        public string ItemCategory { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("uom")]
        public string Uom { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("vendor_code")]
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [JsonProperty("vendor_name")]
        public string VendorName { get; set; }

        /// <summary>
        /// 子项描述
        /// </summary>
        [JsonProperty("item_desc")]
        public string ItemDesc { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [JsonProperty("unit_price")]
        public string UnitPrice { get; set; }
    }
}
