using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Paas.Responses
{
    /// <summary>
    /// Paas平台基础响应
    /// </summary>
    public class PaasBaseResponse
    {
        /// <summary>
        /// 响应码
        /// </summary>
        [JsonProperty("code")]
        public string ResultCode { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk => ResultCode == "0";
    }
}
