using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 获取汇率查询类
    /// </summary>
    public class ErpConversionRequest : BaseEsbRequest
    {
        /// <summary>
        /// 货币
        /// </summary>
        [JsonProperty("p_from_currency")]
        public string FromCurrency { get; set; }

        /// <summary>
        /// 时间（默认当前时间）
        /// </summary>
        [JsonProperty("p_conversion_date")]
        public string ConversionDate { get; set; }

        /// <summary>
        /// 类型（默认(Corporate）
        /// </summary>
        [JsonProperty("p_conversion_type")]
        public string ConversionType { get; set; } = "Corporate";

        /// <summary>
        /// TO（默认CNY）
        /// </summary>
        [JsonProperty("p_to_currency")]
        public string ToCurrency { get; set; }
    }
}
