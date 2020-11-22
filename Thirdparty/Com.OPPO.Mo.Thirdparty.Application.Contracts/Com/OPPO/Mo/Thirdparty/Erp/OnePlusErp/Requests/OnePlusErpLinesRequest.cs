using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 采购单导入主体部分,输入参数
    /// </summary>
    public class OnePlusErpLinesRequest : BaseEsbRequest
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
