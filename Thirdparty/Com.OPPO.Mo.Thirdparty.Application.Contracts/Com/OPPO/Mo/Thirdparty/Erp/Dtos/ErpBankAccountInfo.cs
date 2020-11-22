using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 银行账号信息
    /// </summary>
    public class ErpBankAccountInfo
    {
        /// <summary>
        /// 报销人id
        /// </summary>
        [JsonProperty("emplid")]
        public string EmplId { get; set; }

        /// <summary>
        /// 报销人姓名
        /// </summary>
        [JsonProperty("empl_name")]
        public string EmplName { get; set; }

        /// <summary>
        /// 持卡人姓名
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [JsonProperty("account_ec_id")]
        public string AccountEcId { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        [JsonProperty("bank")]
        public string Bank { get; set; }

        /// <summary>
        /// 支行
        /// </summary>
        [JsonProperty("branch_bank")]
        public string BranchBank { get; set; }

        /// <summary>
        ///  组织编码
        /// </summary>
        [JsonProperty("org_id")]
        public int OrgId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        [JsonProperty("org_name")]
        public string OrgName { get; set; }

        /// <summary>
        ///  公司编码
        /// </summary>
        [JsonProperty("company_code")]
        public string CompanyCode { get; set; }

        /// <summary>
        ///  公司名称
        /// </summary>
        [JsonProperty("company_name")]
        public string company_name { get; set; }

        /// <summary>
        ///  部门
        /// </summary>
        [JsonProperty("department")]
        public string Department { get; set; }

    }
}
