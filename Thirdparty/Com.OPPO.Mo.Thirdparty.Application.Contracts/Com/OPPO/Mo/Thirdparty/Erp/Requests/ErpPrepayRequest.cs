using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 个人借款信息查询输入参数
    /// </summary>
    public class ErpPrepayRequest : BaseEsbRequest
    {
        /// <summary>
        /// 报销人工号
        /// </summary>
        [JsonProperty("emplid")]
        public string EmplId { get; set; }

        /// <summary>
        /// 纳税单位ID
        /// </summary>
        [JsonProperty("ou_id")]
        public string OuId { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonProperty("resp_type")]
        public string RespType { get; set; }
    }
}
