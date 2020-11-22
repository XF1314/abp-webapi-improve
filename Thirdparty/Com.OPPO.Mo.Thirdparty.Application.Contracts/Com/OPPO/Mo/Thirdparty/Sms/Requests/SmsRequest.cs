using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Sms.Requests
{
    /// <summary>
    /// 短信发送
    /// </summary>
    public class SmsRequest : BaseSmsRequest
    {
        public SmsRequest()
        {
            MsgId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 手机号码
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 消息Id,guid格式
        /// </summary>
        [JsonProperty("msgId")]
        public string MsgId { get; set; }
  
        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("msgInfo")]
        public SmsInfo MsgInfo { get; set; }


    }

    /// <summary>
    /// 短信消息体
    /// </summary>
    public class SmsInfo
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("msgBody")]
        public SmsContent MsgBody { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("msgType")]
        public int MsgType { get; set; }
    }

    /// <summary>
    /// 短信内容
    /// </summary>
    public class SmsContent
    {
        /// <summary>
        /// 内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
