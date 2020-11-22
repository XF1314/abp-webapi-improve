using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 设备调拨_设备台账信息 实体信息
    /// </summary>
    public class ErpInstanceRequest : BaseEsbLanguageRequest
    {
        /// <summary>
        /// 设备编码
        /// </summary>
        [JsonProperty("instance_code")]
        public string InstanceCode { get; set; }

        ///// <summary>
        ///// 语言
        ///// </summary>
        //[JsonProperty("language")]
        //public string Language { get; set; }

        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }
    }
}
