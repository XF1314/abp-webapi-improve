using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Ocsm.Responses
{
    /// <summary>
    /// Ocsm webApi response
    /// </summary>
    public class OcsmWebApiResponse
    {
        /// <summary>
        /// <see cref="OcsmWebApiResponse"/>
        /// </summary>
        public OcsmWebApiResponse()
        {
            Body = default;
        }

        /// <summary>
        /// 响应码
        /// </summary>
        [JsonProperty("ErrorCode")]
        public string Code { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// <see cref="OcsmWebApiResponseBody"/>
        /// </summary>
        [JsonProperty("Data")]
        public OcsmWebApiResponseBody Body { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get { return Code == "0" && (Body == null || Body.BussinessCode == "0"); } }

    }

    /// <summary>
    /// Ocsm web api response body
    /// </summary>
    public class OcsmWebApiResponseBody
    {
        /// <summary>
        /// 业务码
        /// </summary>
        [JsonProperty("code")]
        public string BussinessCode { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }
    }

    /// <inheritdoc/>
    public class OcsmWebApiResponseBody<TData> : OcsmWebApiResponseBody
    {
        /// <summary>
        /// <see cref="OcsmWebApiResponseBody{TData}"/>
        /// </summary>
        public OcsmWebApiResponseBody()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        public OcsmWebApiResponseBody<TData> Data { get; set; }
    }
}
