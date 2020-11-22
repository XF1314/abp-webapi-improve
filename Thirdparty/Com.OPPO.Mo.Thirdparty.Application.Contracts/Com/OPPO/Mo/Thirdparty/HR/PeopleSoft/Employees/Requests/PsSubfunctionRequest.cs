using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Requests
{
    /// <summary>
    /// 查询领域信息输入参数
    /// </summary>
    public class PsSubfunctionRequest : BaseEsbRequest
    {
        /// <summary>
        /// 通道代码
        /// </summary>
        [JsonProperty("function_code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonProperty("resp_type")]
        public string Type { get; set; }
    }
}
