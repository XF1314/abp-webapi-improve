using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// Erp供应商信息获取Request
    /// </summary>
    public class ErpVendorInfoGetRequest : BaseEsbRequest
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        [JsonProperty("p_vendor")]
        public string VendorName { get; set; }

        /// <summary>
        /// 签约主体代码
        /// </summary>
        [JsonProperty("p_ou")]
        public string Pou { get; set; }
    }
}
