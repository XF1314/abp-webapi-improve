namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 查询核销预付款输出信息
    /// </summary>
    public class ErpPrepayAmountDto
    {
        /// <summary>
        /// 标题编号
        /// </summary>
        public int ReportHeaderId { get; set; }

        /// <summary>
        /// 预付应用金额
        /// </summary>
        public int PrepayApplyAmount { get; set; }

        /// <summary>
        /// 发票编号
        /// </summary>
        public int? InvoiceId { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// 预付款id
        /// </summary>
        public string PrepayId { get; set; }

        /// <summary>
        /// 预付款
        /// </summary>
        public string PrepayNum { get; set; }

        /// <summary>
        /// 组织id
        /// </summary>
        public int OrgId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string OuName { get; set; }
    }
}
