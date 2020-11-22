using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 采购单导入头部，输入参数
    /// </summary>
    public class OnePlusErpHeadersRequest : BaseEsbRequest
    {
        /// <summary>
        /// 采购单导入信息
        /// </summary>
        [JsonProperty("lines")]
        public string Lines { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonProperty("resp_type")]
        public string RespType { get; set; }
    }
}
