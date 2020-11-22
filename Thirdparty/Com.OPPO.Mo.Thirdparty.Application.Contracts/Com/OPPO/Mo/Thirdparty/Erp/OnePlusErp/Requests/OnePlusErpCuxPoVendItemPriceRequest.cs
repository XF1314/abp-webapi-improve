using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 获取财务系统价格输入参数
    /// </summary>
    public class OnePlusErpCuxPoVendItemPriceRequest : BaseEsbRequest
    {
        /// <summary>
        /// 币种
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 付款条件ID
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 付款条件名称
        /// </summary>
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 主体ID
        /// </summary>
        [JsonProperty("ou_id")]
        public string OuId { get; set; }

        /// <summary>
        /// 主体code
        /// </summary>
        [JsonProperty("ou_name")]
        public string OuName { get; set; }

        /// <summary>
        /// SKU主单位
        /// </summary>
        [JsonProperty("primary_uom_code")]
        public string PrimaryUomCode { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [JsonProperty("vendor_id")]
        public string VendorId { get; set; }


        /// <summary>
        /// 供应商名称
        /// </summary>
        [JsonProperty("vendor_name")]
        public string VendorName { get; set; }

    }
}
