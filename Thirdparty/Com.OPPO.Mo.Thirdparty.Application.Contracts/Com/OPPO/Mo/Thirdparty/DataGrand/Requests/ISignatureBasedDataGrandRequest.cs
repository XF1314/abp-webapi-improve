using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 基于签名的达观搜索请求Interface
    /// </summary>
    public interface ISignatureBasedDataGrandRequest
    {
        /// <summary>
        /// 参数签名，防止请求被劫持篡改参数
        /// </summary>
        [JsonIgnore]
        string Sign { get; set; }
    }
}
