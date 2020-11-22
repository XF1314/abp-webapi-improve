using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 付款信息输出类
    /// </summary>
    public class OnePlusPayTransDto
    {
        /// <summary>
        /// 银行账号
        /// </summary>
        [JsonProperty("BANK_TRANS_NUMBER")]
        public string BankTransNumber { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        [JsonProperty("PAY_AMOUNT")]
        public double? PayAmount { get; set; }

        /// <summary>
        /// MO单号对应ID
        /// </summary>
        [JsonProperty("OA_HEADER_ID")]
        public long OaHeaderId { get; set; }

        /// <summary>
        /// 支付币种
        /// </summary>
        [JsonProperty("PAY_CURRENCY")]
        public string PayCurrency { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        [JsonProperty("PAY_TIME")]
        public DateTime PayTime { get; set; }
    }
}
