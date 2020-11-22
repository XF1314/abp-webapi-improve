using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机服务器信息
    /// </summary>
    public class JmsHostInfo
    {
        /// <summary>
        /// Ip地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 服务器名称
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// 业务s
        /// </summary>
        [JsonProperty("business")]
        public List<string> Businesses { get; set; }

    }
}
