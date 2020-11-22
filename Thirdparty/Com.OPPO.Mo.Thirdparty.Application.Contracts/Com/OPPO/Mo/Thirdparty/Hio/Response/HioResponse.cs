using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hio.Response
{
    public class HioResponse
    {
        /// <summary>
        /// 响应码
        /// </summary>
        [JsonProperty("status")]
        public string Code { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get { return Code == "0"; } }

    }

    /// <inheritdoc/>
    public class HioResponse<TData> : HioResponse
    {
        /// <summary>
        /// <see cref="HioResponse{TData}"/>
        /// </summary>
        public HioResponse()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("data")]
        public TData Data { get; set; }
    }
}


