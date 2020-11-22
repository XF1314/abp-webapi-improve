using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 基础达观搜索数据请求模型
    /// </summary>
    public abstract class BaseDataGrandDataRequest : ISignatureBasedDataGrandRequest,IAppIdInfo
    {
        /// <summary>
        /// <see cref="BaseDataGrandDataRequest"/>
        /// </summary>
        public BaseDataGrandDataRequest()
        {
            DateTime = DateTime.Now;
        }

        /// <summary>
        /// 【必填项】应用标识，由达观搜索提供
        /// </summary>
        [JsonProperty("appid")]
        public string AppId { get;  set; }

        /// <summary>
        /// 【必填项】参数签名，防止请求被劫持篡改参数
        /// </summary>
        [JsonProperty("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 【必填项】调用接口时的秒级时间戳，如1561945554。
        /// 如客户端与服务端的时间相差在10分钟以上，接口调用失败，请确保服务器时间的准确性
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime DateTime { get; private set; }

    }
}
