using Com.OPPO.Mo.Bpm.ActionSoft.Notifications.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Notifications.Dtos
{
    /// <summary>
    /// ActionSoft系统消息发送Input
    /// </summary>
    public class ActionSoftSystemMessageSendInput
    {
        /// <summary>
        /// 消息接收人账户，一个或多个合法的AWS登录账户s
        /// </summary>
        public List<string> To { get; set; }

        /// <summary>
        /// 消息内容，最长2000字符，不支持HTML语法
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// <see cref="ActionSoftSystemMessageLevel"/>
        /// </summary>
        public ActionSoftSystemMessageLevel MessageLevel { get; set; } = ActionSoftSystemMessageLevel.info;

        /// <summary>
        /// 是否向移动端设备发送
        /// </summary>
        public bool IsToMobile { get; set; } = false;
    }
}
