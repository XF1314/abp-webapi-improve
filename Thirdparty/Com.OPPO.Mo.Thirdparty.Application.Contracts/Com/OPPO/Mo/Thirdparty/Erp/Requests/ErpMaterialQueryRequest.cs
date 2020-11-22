using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    ///  物料查询实体类
    /// </summary>
    public class ErpMaterialQueryRequest : BaseEsbRequest
    {
        /// <summary>
        /// 物料代码
        /// </summary>
        [JsonProperty("item_code")]
        public string MaterialCode { get; set; }

        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }
    }
}
