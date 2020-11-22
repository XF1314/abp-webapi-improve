using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Responses
{
    public class PeopleSoftResponse
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

    ///<inheritdoc/>
    public class PeopleSoftResponse<TData> : PeopleSoftResponse
    {
        /// <summary>
        /// <see cref="PeopleSoftResponse{TData}"/>
        /// </summary>
        public PeopleSoftResponse()
        {
            Data = default;
        }

        /// <summary>
        /// 响应体
        /// </summary>
        [JsonProperty("response")]
        public PsResponseBody<TData> Data { get; set; }
    }

    /// <summary>
    /// ps
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class PsResponseBody<TData>
    {
        /// <summary>
        /// <see cref="PsResponseBody{TData}"/>
        /// </summary>
        public PsResponseBody()
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
