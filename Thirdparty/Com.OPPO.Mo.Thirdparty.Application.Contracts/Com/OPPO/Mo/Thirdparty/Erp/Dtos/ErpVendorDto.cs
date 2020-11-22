namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 收款公司信息
    /// </summary>
    public class ErpVendorDto
    {
        /// <summary>
        /// 付款公司OU
        /// </summary>
        public string OuName { get; set; }

        /// <summary>
        /// 供应商代码
        /// </summary>
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankAccountNum { get; set; }

        /// <summary>
        /// 银行
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 支行
        /// </summary>
        public string BranchBank { get; set; }
    }
}
