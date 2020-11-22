using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Paas.Responses
{
    /// <summary>
    /// Paas平台Token信息
    /// </summary>
    public class PaasTokenInfo
    {
        /// <summary>
        /// 应用Id
        /// </summary>
        [JsonProperty("id")]
        public string AppId { get; set; }

        /// <summary>
        /// 应用标识
        /// </summary>
        public string AppTag { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        [JsonProperty("name")]
        public string AppName { get; set; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        [JsonProperty("secret")]
        public string AppSecret { get; set; }

        /// <summary>
        /// 代理Id
        /// </summary>
        public string AgentId { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 访问Token
        /// </summary>
        public string AccessToken { get; set; }

    }
}
