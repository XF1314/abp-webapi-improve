using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Dtos
{
    /// <summary>
    /// 更新离职信息输出
    /// </summary>
    public class LmsInfo
    {
        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
