using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    public class ErpPayResponse
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
    public class ErpPayResponse<TData> : ErpPayResponse
    {
        /// <summary>
        /// <see cref="ErpResponse{TData}"/>
        /// </summary>
        public ErpPayResponse()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("Body")]
        public ErpPayResponseDataBase<TData> Data { get; set; }
    }

    /// <inheritdoc/>
    public class ErpPayResponseDataBase<TData>
    {
        /// <summary>
        /// <see cref="ErpPayResponseDataBase{TData}"/>
        /// </summary>
        public ErpPayResponseDataBase()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("rows")]
        public TData Data { get; set; }
    }
}

