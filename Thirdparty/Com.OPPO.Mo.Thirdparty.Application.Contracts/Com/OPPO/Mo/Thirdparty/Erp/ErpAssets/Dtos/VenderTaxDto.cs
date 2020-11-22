using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos
{

    public class VenderTaxDto
    {
        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 供应商id
        /// </summary>
        [JsonProperty("vendor_id")]
        public int VendorId { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        [JsonProperty("vendor_code")]
        public string VendorCode { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        [JsonProperty("vendor_name")]
        public string VendorName { get; set; }
        /// <summary>
        /// 供应商类型
        /// </summary>
        [JsonProperty("vendor_type")] 
        public string VendorType { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        [JsonProperty("tax_rate")] 
        public double TaxRate { get; set; }
        /// <summary>
        /// 付款货币代码
        /// </summary>
        [JsonProperty("payment_currency_code")] 
        public string PaymentCurrencyCode { get; set; }
    }

}
