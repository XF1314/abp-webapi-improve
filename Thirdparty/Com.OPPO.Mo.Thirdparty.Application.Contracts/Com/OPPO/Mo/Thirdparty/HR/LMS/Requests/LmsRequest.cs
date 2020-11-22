using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Requests
{
    /// <summary>
    /// 更新离职信息请求类
    /// </summary>
    public class LmsRequest : BaseEsbRequest
    {
        /// <summary>
        /// 推送json
        /// </summary>
        [JsonProperty("dataJson")]
        public string DataJson { get; set; }

        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("formInstanceCode")]
        public string FormInstanceCode { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [JsonProperty("userAccount")]
        public string UserAccount { get; set; }
    }
}
