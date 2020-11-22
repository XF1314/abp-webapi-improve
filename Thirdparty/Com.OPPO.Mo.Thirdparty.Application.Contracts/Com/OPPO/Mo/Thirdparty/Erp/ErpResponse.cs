using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp
{
    public class ErpResponse
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
    public class ErpResponse<TData> : ErpResponse
    {
        /// <summary>
        /// <see cref="ErpResponse{TData}"/>
        /// </summary>
        public ErpResponse()
        {
            Body = default;
        }

        /// <summary>
        /// 响应体
        /// </summary>
        [JsonProperty("response")]
        public ErpResponseBody<TData> Body { get; set; }
    }

    /// <summary>
    /// Erp
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class ErpResponseBody<TData>
    {
        /// <summary>
        /// <see cref="ErpResponseBody{TData}"/>
        /// </summary>
        public ErpResponseBody()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("results")]
        public TData Data { get; set; }
    }
}

