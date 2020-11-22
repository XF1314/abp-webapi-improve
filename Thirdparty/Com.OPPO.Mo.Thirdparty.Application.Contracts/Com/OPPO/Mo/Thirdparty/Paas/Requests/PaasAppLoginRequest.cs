using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Paas.Requests
{
    /// <summary>
    /// Paas平台访问Token获取请求
    /// </summary>
    public class PaasAppLoginRequest
    {
        /// <summary>
        /// 应用标识
        /// </summary>
        [JsonProperty("thirdAppTag")]
        public string AppTag { get; set; }

        /// <summary>
        /// 应用加密密钥
        /// </summary>
        [JsonProperty("thirdAppSecret")]
        public string AppEncrptedSecret { get; set; }


    }
}
