using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Dtos
{
    public class DiDiCreateInfo
    {
      
        /// <summary>
        /// 响应码
        /// </summary>
        [JsonProperty("errno")]
        public string Errno { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonProperty("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// <see cref="DiDiContent"/>
        /// </summary>
        [JsonProperty("data")]
        public DiDiContent Data { get; set; }
    }

    public class DiDiContent
    {
        /// <summary>
        /// 审批单ID
        /// </summary>
        public string ApprovalId { get; set; }
    }
}
