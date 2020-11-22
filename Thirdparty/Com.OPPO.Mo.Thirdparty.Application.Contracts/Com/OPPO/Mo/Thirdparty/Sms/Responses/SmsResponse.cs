using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Sms.Responses
{
    public class SmsResponse
    {
        /// <summary>
        /// 返回消息
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("ret")]
        public int Ret { get; set; }
    }
}
