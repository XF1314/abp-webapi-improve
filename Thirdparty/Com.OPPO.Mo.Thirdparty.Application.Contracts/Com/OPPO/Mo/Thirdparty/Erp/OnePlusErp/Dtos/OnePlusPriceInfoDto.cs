using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 拟价单信息
    /// </summary>
    public class OnePlusPriceInfoDto
    {
        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("V_NUM")]
        public string Num { get; set; }

        /// <summary>
        /// 属性编号
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
        /// 消息
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
        public string BkQuotationId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ERP_PERCENTAGE")]
        public string ErpPercentage { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [JsonProperty("UNIT_PRICE")]
        public string UnitPrice { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("OA_NUMBER")]
        public string OaNumber { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("CREATION_DATE")]
        public string CreationDate { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("V_NAME")]
        public string Name { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("PRICE_DISABLE_DATE")]
        public string PriceDisableDate { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("V_ID")]
        public string Id { get; set; }

        /// <summary>
        /// 属性描述
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
        public string PriceActiveDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("SKU")]
        public string SKU { get; set; }

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
        public string Percentage { get; set; }
    }
}
