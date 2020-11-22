using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hio.Requests
{
    /// <summary>
    /// 查询新员工入职培训成绩
    /// </summary>
    public class CourseQueryRequest: BaseEsbRequest
    {
        /// <summary>
        /// 用户工号
        /// </summary>
        [JsonProperty("usercode")]
        public string Usercode { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonProperty("resp_type")]
        public string RespType { get; set; }
    }
}
