namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 付款
    /// </summary>
    public class ErpPaymentDto
    {
        /// <summary>
        /// 国家编码
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// 币种代码
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string DateFrom { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string LedgerID { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string LegalEntityID { get; set; }

        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        /// 组织编号
        /// </summary>
        public string OrgId { get; set; }

        /// <summary>
        /// 付款公司名称（英文）
        /// </summary>
        public string OrgNameUS { get; set; }

        /// <summary>
        /// 付款公司名称
        /// </summary>
        public string OrgNameZhs { get; set; }
    }
}
