using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    public class ErpAssetsResponse
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
    public class ErpAssetsResponse<TData> : ErpResponse
    {
        /// <summary>
        /// <see cref="ErpResponse{TData}"/>
        /// </summary>
        public ErpAssetsResponse()
        {
            Body = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("response")]
        public ErpAssetsResponseBody<TData> Body { get; set; }
    }

    /// <inheritdoc/>
    public class ErpAssetsResponseBody<TData>
    {
        /// <summary>
        /// <see cref="ErpAssetsResponseBody{TData}"/>
        /// </summary>
        public ErpAssetsResponseBody()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("result")]
        public TData Data { get; set; }
    }
}

