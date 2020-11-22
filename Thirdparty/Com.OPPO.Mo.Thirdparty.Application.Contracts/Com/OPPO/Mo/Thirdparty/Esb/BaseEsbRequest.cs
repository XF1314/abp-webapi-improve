using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty
{
    /// <summary>
    /// Esb基础请求Request
    /// </summary>
    public class BaseEsbRequest : ISignatureBasedRequest, IAppIdInfo
    {
        /// <summary>
        /// <see cref="BaseEsbRequest"/>
        /// </summary>
        public BaseEsbRequest()
        {
            AppId = null;
            DateTime = DateTime.Now;
        }

        /// <summary>
        /// AppId
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [JsonProperty(ThirdpartyConsts.EsbSignParameterName)]
        public string Sign { get; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime DateTime { get; private set; }
    }
}
