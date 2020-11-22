using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Requests
{
    /// <summary>
    /// Base realme openapi request
    /// </summary>
    public class RealmeOpenApiBaseRequest : IAppIdInfo, ISignatureBasedRequest
    {
        /// <summary>
        /// <see cref="RealmeOpenApiBaseRequest"/>
        /// </summary>
        public RealmeOpenApiBaseRequest()
        {
            DateTime = DateTime.Now;
        }

        /// <summary>
        /// 应用标识
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [JsonProperty(ThirdpartyConsts.RealmeOpenApiSignParameterName)]
        public string Sign { get; set; }
    }
}
