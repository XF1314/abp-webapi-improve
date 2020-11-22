using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    public class ErpBankResponse
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
    public class ErpBankResponse<TData> : ErpBankResponse
    {
        /// <summary>
        /// <see cref="ErpBankResponse{TData}"/>
        /// </summary>
        public ErpBankResponse()
        {
            Body = default;
        }

        /// <summary>
        /// 响应体
        /// </summary>
        [JsonProperty("response")]
        public ErpBankResponseBody<TData> Body { get; set; }
    }

    /// <summary>
    /// Erp
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class ErpBankResponseBody<TData>
    {
        /// <summary>
        /// <see cref="ErpBankResponseBody{TData}"/>
        /// </summary>
        public ErpBankResponseBody()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("account")]
        public TData Data { get; set; }
    }
}

