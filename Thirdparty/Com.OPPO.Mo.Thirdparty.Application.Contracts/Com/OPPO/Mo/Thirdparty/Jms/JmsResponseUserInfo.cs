using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机响应的用户信息
    /// </summary>
    public  class JmsResponseUserInfo
    {
        /// <summary>
        /// 用户工号
        /// </summary>
        [JsonProperty("userId")]
        public string UserCode { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

    }
}
