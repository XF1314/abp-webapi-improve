using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Requests
{
    /// <summary>
    /// 查询认证信息输入 参数
    /// </summary>
    public class PsAuthenticateRequest : BaseEsbRequest
    {
        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty("emplid")]
        public string EmplId { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonProperty("resp_type")]
        public string Type { get; set; }
    }
}
