using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hio.Requests
{
    /// <summary>
    /// 新员工入职培训成绩
    /// </summary>
    public class CourseGradeInfo
    {
        /// <summary>
        /// 用户工号
        /// </summary>
        [JsonProperty("userCode")]
        public string UserCode { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("trained")]
        public string Trained { get; set; }

        /// <summary>
        /// 成绩
        /// </summary>
        [JsonProperty("score")]
        public int? Score { get; set; }
    }

}
