using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Responses
{
    /// <summary>
    /// 跳板机 Response
    /// </summary>
    public class JmsResponse
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonIgnore]
        public string Message => InnerErrorMessage ?? InnerMessage;

        /// <summary>
        /// 【内部】响应错误消息
        /// </summary>
        [JsonProperty("error")]
        public string InnerErrorMessage { get; set; }

        /// <summary>
        /// 【内部】响应消息
        /// </summary>
        [JsonProperty("message")]
        public string InnerMessage { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get { return Code == "0"; } }

    }

    /// <inheritdoc/>
    public class JmsResponse<TData> : JmsResponse
    {
        /// <summary>
        /// <see cref="JmsResponse{TData}"/>
        /// </summary>
        public JmsResponse()
        {
            Body = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("data")]
        public JmsResponseBody<TData> Body { get; set; }
    }

    /// <inheritdoc/>
    public class JmsResponseBody<TData>
    {
        /// <summary>
        /// <see cref="JmsResponseBody{TData}"/>
        /// </summary>
        public JmsResponseBody()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        public TData Data { get; set; }
    }
}
