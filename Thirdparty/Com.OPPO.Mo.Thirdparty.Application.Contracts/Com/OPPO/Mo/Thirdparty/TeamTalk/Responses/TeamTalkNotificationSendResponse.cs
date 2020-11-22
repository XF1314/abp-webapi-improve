using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.TeamTalk.Responses
{
    /// <summary>
    /// TeamTalk消息通知发送Response
    /// </summary>
    public class TeamTalkNotificationSendResponse
    {
        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [JsonProperty("error_code")]
        public int Code { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        [JsonProperty("error_msg")]
        public string Message { get; set; }
    }
}
