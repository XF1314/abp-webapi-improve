using Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos;
using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Responses
{

    /// <summary>
    /// 查工号返回类型
    /// </summary>
    public class EmpInfoResponse
    {
        [JsonProperty("response")]
        public ResponseBody Response { get; set; }
    }

    public class ResponseBody
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

        public EmpInfoDto Empinfo { get; set; }
    }


}
