using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 获取采购员输入参数
    /// </summary>
    public class OnePlusErpAgentsRequest : BaseEsbRequest
    {
        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// 组织ID
        /// </summary>
        [JsonProperty("agent_id")]
        public string Id { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        [JsonProperty("agent_name ")]
        public string Name { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty("employee_number")]
        public string Number { get; set; }

        
    }
}
