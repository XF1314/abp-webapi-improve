using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 付款公司分页查询实体
    /// </summary>
    public class ErpPaymentRequest : BaseEsbRequest
    {
        /// <summary>
        /// 固定资产编号
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// page_size
        /// </summary>
        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        /// <summary>
        /// page_index
        /// </summary>
        [JsonProperty("page_index")]
        public int PageIndex { get; set; }
    }

}
