using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    ///物料现有量查询实体类
    /// </summary>
    public class ErpOnhandQtyQueryRequest : BaseEsbRequest
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 组织编码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        [JsonProperty("locator_code")]
        public string LocatorCode { get; set; }


        /// <summary>
        /// 部门编码
        /// </summary>
        [JsonProperty("subinv_code")]
        public string SubinvCode { get; set; }
    }
}
