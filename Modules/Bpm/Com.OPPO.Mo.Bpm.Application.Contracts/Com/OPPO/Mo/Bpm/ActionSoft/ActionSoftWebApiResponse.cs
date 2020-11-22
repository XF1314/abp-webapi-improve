using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// ActionSoft WebApi Response
    /// </summary>
    public class ActionSoftWebApiResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonIgnore]
        public bool IsOk => Result.Equals("ok", StringComparison.OrdinalIgnoreCase);
    }

    /// <inheritdoc/>
    public class ActionSoftWebApiResponse<TData> : ActionSoftWebApiResponse
    {
        /// <summary>
        /// 数据
        /// </summary>
        public TData Data { get; set; } = default;
    }
}
