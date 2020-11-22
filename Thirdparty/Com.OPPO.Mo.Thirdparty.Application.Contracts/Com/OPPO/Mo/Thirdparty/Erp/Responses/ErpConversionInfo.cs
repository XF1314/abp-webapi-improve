using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    /// <summary>
    /// Erp汇率换算信息
    /// </summary>
    public class ErpConversionInfo
    {
        /// <summary>
        /// 换算日期
        /// </summary>
        [JsonProperty("conversion_date")]
        public DateTime ConversionDate { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        [JsonProperty("conversion_rate")]
        public string ConversionRate { get; set; }

        /// <summary>
        /// 反向转换率
        /// </summary>
        [JsonProperty("inverse_conversion_rate")]
        public string InverseConversionRate { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty("conversion_type")]
        public string ConversionType { get; set; }

        /// <summary>
        /// 货币From
        /// </summary>
        [JsonProperty("from_currency")]
        public string FromCurrency { get; set; }

        /// <summary>
        /// 货币To
        /// </summary>
        [JsonProperty("to_currency")]
        public string ToCurrency { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        /// <summary>
        /// 上次更新日期
        /// </summary>
        [JsonProperty("last_update_date")]
        public DateTime LastUpdateDate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("creation_date")]
        public DateTime CreateDate { get; set; }
    }
}
