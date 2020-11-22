using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 设备调拨_设备台账信息信息查询实体类
    /// </summary>
    public class ErpInstanceInfoQueryRequest : BaseEsbLanguageRequest
    {
        /// <summary>
        /// 设备编码
        /// </summary>
        [JsonProperty("instance_code ")]
        public string InstanceCode { get; set; }

        ///// <summary>
        ///// 语言
        ///// </summary>
        //[JsonProperty("language ")]
        //public string Language { get; set; }

        /// <summary>
        /// 组织编码
        /// </summary>
        [JsonProperty("org_code ")]
        public string OrgCode { get; set; }
    }
}
