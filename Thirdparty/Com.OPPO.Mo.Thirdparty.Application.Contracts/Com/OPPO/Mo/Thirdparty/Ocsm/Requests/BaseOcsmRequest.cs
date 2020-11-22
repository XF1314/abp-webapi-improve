using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Ocsm.Requests
{
    /// <summary>
    /// Ocsm基础Request
    /// </summary>
    public  class BaseOcsmRequest : ISignatureBasedRequest, IAppIdInfo
    {
        /// <summary>
        /// <see cref="BaseOcsmRequest"/>
        /// </summary>
        public BaseOcsmRequest()
        {
            AppId = null;
            DateTime = DateTime.Now;//Convert.ToDateTime("2020-07-09 16:03:00")
        }

        /// <summary>
        /// AppId
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [JsonProperty("sign")]
        public string Sign { get; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime DateTime { get; private set; }
    }
}
