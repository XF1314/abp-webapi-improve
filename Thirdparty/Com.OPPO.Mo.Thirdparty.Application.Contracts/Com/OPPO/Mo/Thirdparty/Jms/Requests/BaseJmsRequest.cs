using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Requests
{
    /// <summary>
    /// 跳板机 Base request
    /// </summary>
    public class BaseJmsRequest 
    {
        /// <summary>
        /// <see cref="BaseJmsRequest"/>
        /// </summary>
        public BaseJmsRequest()
        {
            DateTime = DateTime.Now;
        }

        /// <summary>
        /// 【必填项】调用接口时的秒级时间戳，如1561945554。
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime DateTime { get; private set; }

    }
}
