using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Responses
{
    /// <summary>
    /// Realme response
    /// </summary>
    public class RealmeOpenApiResponse
    {
        /// <summary>
        /// <see cref="RealmeOpenApiResponse"/>
        /// </summary>
        public RealmeOpenApiResponse()
        {
            Body = default;
        }

        /// <summary>
        /// 响应码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// <see cref="RealmeOpenApiResponseBody"/>
        /// </summary>
        [JsonProperty("message")]
        public RealmeOpenApiResponseBody Body { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get { return Code == "0" && (Body == null || Body.BussinessCode == "0"); } }

    }

    /// <summary>
    /// Ocsm web api response body
    /// </summary>
    public class RealmeOpenApiResponseBody
    {
        /// <summary>
        /// 业务码
        /// </summary>
        [JsonProperty("state")]
        public string BussinessCode { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }
    }

    /// <inheritdoc/>
    public class RealmeOpenApiResponseBody<TData> : RealmeOpenApiResponseBody
    {
        /// <summary>
        /// <see cref="RealmeOpenApiResponseBody{TData}"/>
        /// </summary>
        public RealmeOpenApiResponseBody()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        public RealmeOpenApiResponseBody<TData> Data { get; set; }
    }
}
