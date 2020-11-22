using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    public class ErpVendorInfo
    {
        /// <summary>
        /// 付款公司OU
        /// </summary>
        [JsonProperty("ou_name")]
        public string OuName { get; set; }

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
        /// 币种
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 银行账户名称
        /// </summary>
        [JsonProperty("bank_account_name")]
        public string BankAccountName { get; set; }

        /// <summary>
        /// 银行账户
        /// </summary>
        [JsonProperty("bank_account_num")]
        public string BankAccountNum { get; set; }

        /// <summary>
        /// 银行
        /// </summary>
        [JsonProperty("bank")]
        public string Bank { get; set; }

        /// <summary>
        /// 银行分行
        /// </summary>
        [JsonProperty("branch_bank")]
        public string BranchBank { get; set; }

    }
}
