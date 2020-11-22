using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 供应商信息
    /// </summary>
    public class OnplusErpVendorDto
    {
        /// <summary>
        /// 银行账号
        /// </summary>
        [JsonProperty("BANK_ACCOUNT_NAME")]
        public string BankAccountName { get; set; }

        /// <summary>
        /// 供应商站点名称
        /// </summary>
        [JsonProperty("VENDOR_SITE_NAME")]
        public string VendorSiteName { get; set; }

        /// <summary>
        /// 组织ID
        /// </summary>
        [JsonProperty("ORG_ID")]
        public string OrgId { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        [JsonProperty("VENDOR_NUMBER")]
        public string VendorNumber { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [JsonProperty("IMPORT_DATE")]
        [DataType(DataType.Date)]
        public DateTime? ImportDate { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [JsonProperty("CURRENCY")]
        public string Currency { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        [JsonProperty("ORG_NAME")]
        public string OrgName { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("TAX_NUMBER")]
        public string TaxNumber { get; set; }

        /// <summary>
        /// 增值税代码
        /// </summary>
        [JsonProperty("VAT_CODE")]
        public string VatCode { get; set; }

        /// <summary>
        /// 分行名称
        /// </summary>
        [JsonProperty("BANK_BRANCH_NAME")]
        public string BankBranchName { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [JsonProperty("BANK_NAME")]
        public string BankName { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        [JsonProperty("PAYMENT_METHOD")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("PAYMENT_TERMS")]
        public string PaymentTerms { get; set; }

        /// <summary>
        /// 供应商类型
        /// </summary>
        [JsonProperty("VENDER_TYPE")]
        public string VenderType { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("BS_SCOPE")]
        public string BsScope { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [JsonProperty("HB_ENABLE_FLAG")]
        public string HBEnableFlag { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        [JsonProperty("PERCENTAGE_RATE")]
        public string PercentageRate { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [JsonProperty("VENDOR_NAME")]
        public string VendorName { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        [JsonProperty("VENDOR_ID")]
        public string VendorId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("PURCHASE_TYPE")]
        public string PurchaseType { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        [JsonProperty("BANK_ACCOUNT_NUM")]
        public string BankAccountNum { get; set; }
    }
}
