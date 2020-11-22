using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 拟价单输出信息
    /// </summary>
    public class OnePlusErpPriceInfo
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 拟价单信息
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }
    }

}
