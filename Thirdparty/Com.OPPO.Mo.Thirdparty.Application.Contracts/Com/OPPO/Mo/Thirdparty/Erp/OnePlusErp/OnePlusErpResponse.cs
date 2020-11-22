using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp
{
    public class OnePlusErpResponse
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get { return Code == "0"; } }

    }

    /// <inheritdoc/>
    public class OnePlusErpResponse<TData> : OnePlusErpResponse
    {
        /// <summary>
        /// <see cref="ErpResponse{TData}"/>
        /// </summary>
        public OnePlusErpResponse()
        {
            Body = default;
        }

        /// <summary>
        /// 响应体
        /// </summary>
        [JsonProperty("response")]
        public OnePlusErpResponseBody<TData> Body { get; set; }
    }

    /// <summary>
    /// Erp
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class OnePlusErpResponseBody<TData>
    {
        /// <summary>
        /// <see cref="OnePlusErpResponseBody{TData}"/>
        /// </summary>
        public OnePlusErpResponseBody()
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

