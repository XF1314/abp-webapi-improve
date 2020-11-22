using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    public class ErpDepResponse
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
    public class ErpDepResponse<TData> : ErpResponse
    {
        /// <summary>
        /// <see cref="ErpResponse{TData}"/>
        /// </summary>
        public ErpDepResponse()
        {
            Data = default;
        }

        /// <summary>
        /// 响应体
        /// </summary>
        [JsonProperty("response")]
        public ErpDepResponseBody<TData> Data { get; set; }
    }

    /// <summary>
    /// Erp
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class ErpDepResponseBody<TData>
    {
        /// <summary>
        /// <see cref="ErpDepResponseBody{TData}"/>
        /// </summary>
        public ErpDepResponseBody()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("dept")]
        public TData Data { get; set; }
    }
}

