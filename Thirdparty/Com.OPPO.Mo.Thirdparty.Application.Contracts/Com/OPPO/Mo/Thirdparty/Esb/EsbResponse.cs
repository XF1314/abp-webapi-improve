using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty
{
    /// <summary>
    /// Esb Response
    /// </summary>
    public class EsbResponse
    {
        /// <summary>
        /// <see cref="EsbResponseBody"/>
        /// </summary>
        [JsonProperty("response")]
        public EsbResponseBody Body { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get { return Body != null && Body.BussinessCode == "0"; } }
    }

    /// <summary>
    /// Esb Response
    /// </summary>
    public class EsbResponse<TData>
    {
        /// <summary>
        /// <see cref="EsbResponseBody{TData}"/>
        /// </summary>
        [JsonProperty("response")]
        public EsbResponseBody<TData> Body { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get { return Body != null && Body.BussinessCode == "0"; } }
    }

    /// <summary>
    /// Esb response body
    /// </summary>
    public class EsbResponseBody
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
    public class EsbResponseBody<TData> : EsbResponseBody
    {
        /// <summary>
        /// <see cref="EsbResponseBody{TData}"/>
        /// </summary>
        public EsbResponseBody()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        public TData Data { get; set; }
    }
}
