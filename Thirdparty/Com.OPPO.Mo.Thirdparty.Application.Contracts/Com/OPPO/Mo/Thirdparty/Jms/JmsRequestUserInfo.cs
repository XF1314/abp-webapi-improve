using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机请求用户信息
    /// </summary>
    public class JmsRequestUserInfo
    {
        /// <summary>
        /// 用户工号
        /// </summary>
        [JsonProperty("usercode")]
        public string UserCode { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }
    }
}
