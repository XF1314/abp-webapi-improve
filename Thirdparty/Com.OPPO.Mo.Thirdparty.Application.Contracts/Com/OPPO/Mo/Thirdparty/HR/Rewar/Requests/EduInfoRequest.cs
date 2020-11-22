using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.Rewar.Requests
{
    /// <summary>
    /// 教育经历信息查询实体信息
    /// </summary>
    public class EduInfoRequest : PsHrBaseRequest
    {
        public EduInfoRequest()
        {
            Data = new List<EduInfo>();
        }

        /// <summary>
        /// 请求信息
        /// </summary>
        [JsonProperty("data")]
        public List<EduInfo> Data { get; set; }
    }


    public class EduInfo
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        [JsonProperty("EMPLID")]
        public string EmplId { get; set; }
    }
}
