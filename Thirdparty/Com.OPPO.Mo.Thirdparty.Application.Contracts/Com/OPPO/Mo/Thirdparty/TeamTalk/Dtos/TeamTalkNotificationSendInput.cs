using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.TeamTalk.Dtos
{
    /// <summary>
    /// TeamTalk消息通知发送Input
    /// </summary>
    public class TeamTalkNotificationSendInput
    {
        /// <summary>
        /// 发送人工号
        /// </summary>
        public string SendUserCode { get; set; }

        /// <summary>
        /// 接收人工号s
        /// </summary>
        public List<string> RecieveUserCodes { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Message { get; set; }
    }

}
