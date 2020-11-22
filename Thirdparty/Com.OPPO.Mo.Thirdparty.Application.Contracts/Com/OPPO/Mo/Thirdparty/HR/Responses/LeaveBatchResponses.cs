using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Responses
{
    public class LeaveBatchResponses
    {
        [JsonProperty("response")]
        public LeaveBatchBody Body { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get { return Body != null && Body.BussinessCode == "0"; } }
    }
    public class LeaveBatchBody
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
}
