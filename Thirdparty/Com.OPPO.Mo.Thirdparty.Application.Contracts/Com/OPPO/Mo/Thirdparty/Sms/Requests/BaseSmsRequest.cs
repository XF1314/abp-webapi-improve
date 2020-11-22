using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Sms.Requests
{
    /// <summary>
    ///短信发送基础请求Request
    /// </summary>
    public class BaseSmsRequest 
    {
        public BaseSmsRequest()
        {
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("createTime")]
        [JsonConverter(typeof(DateTimeMillisecondConverter))]
        public DateTime CreateTime { get; private set; }

    }
}
