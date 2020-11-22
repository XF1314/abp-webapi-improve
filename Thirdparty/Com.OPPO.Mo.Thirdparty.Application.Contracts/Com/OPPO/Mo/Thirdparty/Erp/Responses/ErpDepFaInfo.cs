using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    /// <summary>
    /// EAM-设备调拨_部门账户信息 输出类
    /// </summary>
    public class ErpDepFaInfo
    {
        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("location_desc")]
        public string LocationDesc { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }
    }
}
