using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 认证信息输出类
    /// </summary>
    public class PsQualificationInfo
    {
        /// <summary>
        /// 成功或是失败消息
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 0表示成功，大于0表示失败
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
