namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 银行账号信息
    /// </summary>
    public class ErpBankAccountDto
    {
        /// <summary>
        /// 报销人id
        /// </summary>
        public string EmplId { get; set; }

        /// <summary>
        /// 报销人姓名
        /// </summary>
        public string EmplName { get; set; }

        /// <summary>
        /// 持卡人姓名
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string AccountEcId { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 支行
        /// </summary>
        public string BranchBank { get; set; }

        /// <summary>
        ///  组织编码
        /// </summary>
        public int OrgId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrgName { get; set; }

        /// <summary>
        ///  公司编码
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        ///  公司名称
        /// </summary>
        public string company_name { get; set; }

        /// <summary>
        ///  部门
        /// </summary>
        public string Department { get; set; }
    }
}
