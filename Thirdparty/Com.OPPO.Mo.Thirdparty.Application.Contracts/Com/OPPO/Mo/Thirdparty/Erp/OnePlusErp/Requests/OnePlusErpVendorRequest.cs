using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 一加采购检查供应商登记注册号输入参数
    /// </summary>
    public class OnePlusErpVendorRequest : BaseEsbRequest
    {
        /// <summary>
        /// 组织ID
        /// </summary>
        [JsonProperty("org_id")]
        public string OrgId { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        [JsonProperty("vendor_number")]
        public string VendorNumber { get; set; }
    }
}
