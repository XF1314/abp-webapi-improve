using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Responses
{
    /// <summary>
    /// DiDi创建审批输出类
    /// </summary>
    public class DiDiCreateResponse
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public string Errno { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string Errmsg { get; set; }

        /// <summary>
        /// 审批信息
        /// </summary>
        public Content Data { get; set; }
    }

    public class Content
    {
        /// <summary>
        /// 审批单ID
        /// </summary>
        [JsonProperty("approval_id")]
        public string ApprovalId { get; set; }
    }
}
