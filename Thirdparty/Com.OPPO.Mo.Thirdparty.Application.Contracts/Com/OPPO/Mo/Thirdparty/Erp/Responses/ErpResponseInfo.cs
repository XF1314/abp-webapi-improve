using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    public class ErpResponseInfo
    {
        /// <summary>
        /// 编码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}
