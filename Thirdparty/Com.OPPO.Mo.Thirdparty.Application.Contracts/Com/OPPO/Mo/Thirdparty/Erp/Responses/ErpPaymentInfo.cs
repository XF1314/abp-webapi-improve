using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    /// <summary>
    /// 付款
    /// </summary>
    public class ErpPaymentInfo
    {
        /// <summary>
        /// 国家编码
        /// </summary>
       [JsonProperty("COUNTRY_CODE")]
        public string CountryCode { get; set; }

        /// <summary>
        /// 币种代码
        /// </summary>
        [JsonProperty("CURRENCY_CODE")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// FROM
        /// </summary>
        [JsonProperty("DATE_FROM")]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("LEDGER_ID")]
        public string LedgerID { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("LEGAL_ENTITY_ID")]
        public string LegalEntityID { get; set; }

        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("ORG_CODE")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 组织编号
        /// </summary>
        [JsonProperty("ORG_ID")]
        public string OrgId { get; set; }

        /// <summary>
        /// 付款公司名称（英文）
        /// </summary>
        [JsonProperty("ORG_NAME_US")]
        public string OrgNameUS { get; set; }

        /// <summary>
        /// 付款公司名称
        /// </summary>
        [JsonProperty("ORG_NAME_ZHS")]
        public string OrgNameZhs { get; set; }    
    }
}
