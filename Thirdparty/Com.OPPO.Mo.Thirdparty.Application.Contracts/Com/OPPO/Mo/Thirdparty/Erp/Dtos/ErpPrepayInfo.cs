using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 个人借款信息
    /// </summary>
    public class ErpPrepayInfo
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        [JsonProperty("vendor_num")]
        public string VendorNum { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [JsonProperty("vendor_name")]
        public string VendorName { get; set; }

        /// <summary>
        /// 纳税单位ID
        /// </summary>
        [JsonProperty("ou_id")]
        public int? OuId { get; set; }

        /// <summary>
        /// 纳税单名称
        /// </summary>
        [JsonProperty("ou_name")]
        public string OuName { get; set; }

        /// <summary>
        /// 预付款编号
        /// </summary>
        [JsonProperty("prepay_id")]
        public int? PrepayId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("doc_sequence_value")]
        public int? DocSequenceValue { get; set; }

        /// <summary>
        /// 贷款日期
        /// </summary>
        [JsonProperty("prepay_gl_date")]
        public DateTime? PrepayGlDate { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        [JsonProperty("prepay_amount")]
        public int? PrepayAmount { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        [JsonProperty("prepay_amount_remaining")]
        public double PrepayAmountRemaining { get; set; }

        /// <summary>
        /// 预计还款时间
        /// </summary>
        [JsonProperty("expected_time")]
        public DateTime? ExpectedTime { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("amount_remaining")]
        public double AmountRemaining { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 借款用途
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 币种编码
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }
}
