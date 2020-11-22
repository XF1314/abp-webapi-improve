using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Notifications
{
    /// <summary>
    /// ActionSoft通知相关命令
    /// </summary>
    public class ActionSoftNotificationCommands
    {
        /// <summary>
        /// 系统消息是否可用
        /// </summary>
        public const string CheckSystemMessageEnabled = "notification.sysmsg.check";

        /// <summary>
        /// 发送一封内部电子邮件。要正常使用该API，需要当前AWS PaaS安装了"内部邮件"应用（appId:com.actionsoft.apps.email)
        /// </summary>
        public const string SendInnerMail = "notification.innermail.send";

        /// <summary>
        /// 发送一封含附件的互联网电子邮件(同步)
        /// </summary>
        public const string SendSyncEmail = "notification.email.sync.send";

        /// <summary>
        /// 给用户发送一条消息。要正常使用该API，需要当前AWS PaaS安装了"通知中心"应用（appId:com.actionsoft.apps.notification)
        /// </summary>
        public const string SendMessage = "notification.msg.send";

        /// <summary>
        /// 以admin身份给用户发送一条系统消息。要正常使用该API，需要当前AWS PaaS安装了"通知中心"应用（appId:com.actionsoft.apps.notification)
        /// </summary>        
        public const string SendSystemMessage = "notification.sysmsg.send";

        /// <summary>
        /// 发送一封含附件的互联网电子邮件(异步)
        /// </summary>
        public const string SendAsyncEmail = "notification.email.async.send";
    }
}
