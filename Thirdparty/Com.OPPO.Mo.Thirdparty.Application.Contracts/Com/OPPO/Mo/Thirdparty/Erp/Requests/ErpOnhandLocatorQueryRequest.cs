using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 库存现有量查询实体类
    /// </summary>
    public class ErpOnhandLocatorQueryRequest : BaseEsbRequest
    {
        /// <summary>
        /// 组织编码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 转出部门编码
        /// </summary>
        [JsonProperty("subinv_code")]
        public string SubinvCode { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        [JsonProperty("item_code")]
        public string Code { get; set; }
    }
}
