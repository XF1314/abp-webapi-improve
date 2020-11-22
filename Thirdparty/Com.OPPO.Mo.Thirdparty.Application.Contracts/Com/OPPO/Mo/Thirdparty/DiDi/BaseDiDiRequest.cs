using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty
{
    /// <summary>
    /// 滴滴基础请求Request
    /// </summary>
    public class BaseDiDiRequest : ISignatureBasedRequest, IAppIdInfo
    {
        /// <summary>
        /// <see cref="BaseDiDiRequest"/>
        /// </summary>
        public BaseDiDiRequest()
        {
            AppId = null;
            DateTime = DateTime.Now;
        }

        /// <summary>
        /// 签名
        /// </summary>
        [JsonProperty(ThirdpartyConsts.DiDiOpenApiSignParameterName)]
        public string Sign { get; set; }

        /// <summary>
        /// 申请应用时分配的AppKey
        /// </summary>
        [JsonProperty("client_id")]
        public string AppId { get; set; }

        /// <summary>
        /// 当前时间戳
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime DateTime { get; private set; }
 
    }
}
