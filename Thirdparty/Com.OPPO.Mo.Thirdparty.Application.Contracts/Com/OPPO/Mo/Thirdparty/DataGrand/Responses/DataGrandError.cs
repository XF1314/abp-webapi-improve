using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Responses
{
    /// <summary>
    /// 达观搜索错误信息
    /// </summary>
    public class DataGrandError
    {
        /// <summary>
        /// 错误编码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
