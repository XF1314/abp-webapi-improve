using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Responses
{
    public class DiDiResponse
    {
        /// <summary>
        /// <see cref="DiDiResponse"/>
        /// </summary>
        public DiDiResponse()
        {
            Body = default;
        }
        /// <summary>
        /// 响应码
        /// </summary>
        [JsonProperty("errno")]
        public string Code { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonProperty("errmsg")]
        public string Message { get; set; }

        /// <summary>
        /// <see cref="DiDiBodyResponse"/>
        /// </summary>
        [JsonProperty("data")]
        public DiDiBodyResponse Body { get; set; }
    }

    public class DiDiBodyResponse
    {
        /// <summary>
        /// 相应内容
        /// </summary>
        [JsonProperty("data")]
        public string Body { get; set; }
    }

    public class DiDiBodyResponse<T>: DiDiResponse
    {
        /// <summary>
        /// 相应内容
        /// </summary>
        [JsonProperty("data")]
        public DiDiBodyResponse<T> Data { get; set; }
    }
}
