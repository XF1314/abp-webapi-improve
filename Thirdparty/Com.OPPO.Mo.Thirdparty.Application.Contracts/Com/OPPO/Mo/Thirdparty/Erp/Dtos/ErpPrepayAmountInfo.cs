using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 查询核销预付款输出信息
    /// </summary>
    public class ErpPrepayAmountInfo
    {
        /// <summary>
        /// 标题编号
        /// </summary>
        [JsonProperty("report_header_id")]
        public int ReportHeaderId { get; set; }

        /// <summary>
        /// 预付应用金额
        /// </summary>
        [JsonProperty("prepay_apply_amount")]
        public int PrepayApplyAmount { get; set; }

        /// <summary>
        /// 发票编号
        /// </summary>
        [JsonProperty("invoice_id")]
        public int? InvoiceId { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        [JsonProperty("vendor_id")]
        public int VendorId { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        [JsonProperty("vendor_code")]
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [JsonProperty("vendor_name")]
        public string VendorName { get; set; }

        /// <summary>
        /// 预付款id
        /// </summary>
        [JsonProperty("prepay_id")]
        public string PrepayId { get; set; }

        /// <summary>
        /// 预付款
        /// </summary>
        [JsonProperty("prepay_num")]
        public string PrepayNum { get; set; }

        /// <summary>
        /// 组织id
        /// </summary>
        [JsonProperty("org_id")]
        public int OrgId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ou_name")]
        public string OuName { get; set; }
    }
}
