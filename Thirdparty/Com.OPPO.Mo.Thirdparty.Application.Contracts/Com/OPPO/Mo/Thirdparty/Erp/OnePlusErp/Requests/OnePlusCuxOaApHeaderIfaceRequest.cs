using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 报销通用接口(heard信息)输入参数
    /// </summary>
    public class OnePlusCuxOaApHeaderIfaceRequest : BaseEsbRequest
    {
        /// <summary>
        /// json格式数据
        /// </summary>
        [JsonProperty("lines")]
        public string Lines { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonProperty("resp_type")]
        public string RespType { get; set; }
    }
}
