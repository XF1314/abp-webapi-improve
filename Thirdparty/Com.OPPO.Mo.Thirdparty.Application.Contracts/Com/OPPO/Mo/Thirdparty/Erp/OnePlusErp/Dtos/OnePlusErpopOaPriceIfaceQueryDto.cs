using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 获取拟价单信息输出信息
    /// </summary>
    public class OnePlusErpopOaPriceIfaceQueryDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        [JsonProperty("V_NUM")]
        public string Num { get; set; }

        /// <summary>
        /// skuId
        /// </summary>
        [JsonProperty("SKU_ID")]
        public string SkuId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("RESP_DATE")]
        public string RespDate { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("OU_NAME")]
        public string OuName { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        [JsonProperty("MESSAGE")]
        public string Message { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [JsonProperty("CURRENCY")]
        public string Currency { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("BK_QUOTATION_ID")]
        public long? BkQuotationId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ERP_PERCENTAGE")]
        public double? ErpPercentAge { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [JsonProperty("UNIT_PRICE")]
        public double? UNIT_PRICE { get; set; }

        /// <summary>
        /// oa 编号
        /// </summary>
        [JsonProperty("OA_NUMBER")]
        public string OaNumber { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("CREATION_DATE")]
        public long? CreationDate { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("V_NAME")]
        public string Name { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("PRICE_DISABLE_DATE")]
        public long? PriceDisableDate { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("V_ID")]
        public int? V_ID { get; set; }

        /// <summary>
        /// SKU描述
        /// </summary>
        [JsonProperty("SKU_DESC")]
        public string SkuDesc { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("PRICE_STATUS")]
        public string PriceStatus { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("PRICE_ACTIVE_DATE")]
        public long? PriceActiveDate { get; set; }

        /// <summary>
        /// SKU
        /// </summary>
        [JsonProperty("SKU")]
        public string Sku { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("QUANTITY")]
        public string Quantity { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("TRANS_PRICE_FLAG")]
        public string TransPriceFlag { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("PERCENTAGE")]
        public double? Percentage { get; set; }
    }
}
