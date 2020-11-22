using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.TeamTalk.Requests
{
    /// <summary>
    /// TeamTalk消息通知发送Request
    /// </summary>
    public class TeamTalkNotificationSendRequest : BaseEsbRequest
    {
        [JsonProperty("send_data")]
        private string notificationInfo => JsonConvert.SerializeObject(NotificationInfo);

        /// <summary>
        /// <see cref="TeamTalkNotificationInfo"/>
        /// </summary>
        [JsonIgnore]
        public TeamTalkNotificationInfo NotificationInfo { get; set; }
    }

    /// <summary>
    /// TeamTalk消息通知信息
    /// </summary>
    public class TeamTalkNotificationInfo
    {
        /// <summary>
        /// 发送人工号
        /// </summary>
        [JsonProperty("from_user")]
        public string SendUserCode { get; set; } = "oppo_mo_platform";

        /// <summary>
        /// 接收人工号s
        /// </summary>
        [JsonProperty("to_user_list")]
        public List<string> RecieveUserCodes { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}
