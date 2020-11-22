using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// MO费用报销驳回处理输入参数
    /// </summary>
    public class ErpProcessRejectRequest : BaseEsbRequest
    {
        /// <summary>
        /// 单据id
        /// </summary>
        [JsonProperty("p_doc_id")]
        public string DocId { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("p_language")]
        public string Language { get; set; }

        /// <summary>
        /// 来源类型
        /// </summary>
        [JsonProperty("p_souce_type")]
        public string SouceType { get; set; }
    }
}
