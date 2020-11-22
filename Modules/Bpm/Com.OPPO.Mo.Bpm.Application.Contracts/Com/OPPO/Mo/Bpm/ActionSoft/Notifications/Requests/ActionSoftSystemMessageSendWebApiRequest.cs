using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Notifications.Requests
{
    /// <summary>
    /// ActionSoft系统消息发送WebApi请求
    /// </summary>
    public class ActionSoftSystemMessageSendWebApiRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftSystemMessageSendWebApiRequest"/>
        /// </summary>
        public ActionSoftSystemMessageSendWebApiRequest() : base(ActionSoftNotificationCommands.SendSystemMessage)
        {
        }

        /// <summary>
        /// 消息接收人账户，一个或多个合法的AWS登录账户（多个使用空格隔开）
        /// </summary>
        [JsonConverter(typeof(ListAndSpacesSeparatedStringConverter))]
        public List<string> To { get; set; }

        /// <summary>
        /// 消息内容，最长2000字符，不支持HTML语法
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// <see cref="ActionSoftSystemMessageLevel"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("level")]
        public ActionSoftSystemMessageLevel MessageLevel { get; set; }

        /// <summary>
        /// 是否向移动端设备发送
        /// </summary>
        [JsonProperty("toMobile")]
        public bool IsToMobile { get; set; }
    }

    public enum ActionSoftSystemMessageLevel
    {
        info = 1,

        error = 2,

        warnning = 3
    }
}
