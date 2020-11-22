using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 获取财务系统价格输出信息
    /// </summary>
    public class OnePlusErpCuxPoVendItemPriceDto
    {
        /// <summary>
        /// 币种
        /// </summary>
        [JsonProperty("CURRENCY_CODE")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("LATEST_PURCH_PRICE")]
        public string LatestPurchPrice { get; set; }

        /// <summary>
        /// 主体名称
        /// </summary>
        [JsonProperty("OU_NAME")]
        public string OU_NAME { get; set; }

        /// <summary>
        /// 主体Id
        /// </summary>
        [JsonProperty("OU_ID")]
        public string OuId { get; set; }

        /// <summary>
        /// SKU
        /// </summary>
        [JsonProperty("ITEM_NAME")]
        public string ItemName { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [JsonProperty("UNIT_PRICE")]

        public double? UnitPrice { get; set; }

        /// <summary>
        /// 供应商简称
        /// </summary>
        [JsonProperty("VENDOR_SHORT_NAME")]
        public string VendorShortName { get; set; }

        /// <summary>
        /// 供应商全称
        /// </summary>
        [JsonProperty("VENDOR_NAME")]
        public string VendorName { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("TN_FLAG")]
        public string TN_FLAG { get; set; }

        /// <summary>
        /// SKU主单位
        /// </summary>
        [JsonProperty("PRIMARY_UOM_CODE")]
        public string PrimaryUomCode { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("DESCRIPTION")]
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [JsonProperty("VENDOR_ID")]
        public string VendorId { get; set; }

        /// <summary>
        /// 付款条件ID
        /// </summary>
        [JsonProperty("ITEM_ID")]
        public string ItemId { get; set; }
    }
}
