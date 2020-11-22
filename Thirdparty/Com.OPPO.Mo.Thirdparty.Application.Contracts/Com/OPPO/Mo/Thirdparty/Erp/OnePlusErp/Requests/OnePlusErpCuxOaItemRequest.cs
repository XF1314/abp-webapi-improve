using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// SKU基础数据查询输入参数
    /// </summary>
    public class OnePlusErpCuxOaItemRequest : BaseEsbRequest
    {
        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// ERP库存组织ID
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// SKU code
        /// </summary>
        [JsonProperty("sku_code")]
        public string SkuCode { get; set; }

        /// <summary>
        /// ERP Item Id
        /// </summary>
        [JsonProperty("sku_id")]
        public string SkuId { get; set; }

        /// <summary>
        /// SKU主单位
        /// </summary>
        [JsonProperty("uom")]
        public string Uom { get; set; }
    }
}
