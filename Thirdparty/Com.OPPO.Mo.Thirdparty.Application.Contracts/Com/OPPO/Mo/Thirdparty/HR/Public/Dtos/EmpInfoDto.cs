using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos
{
    /// <summary>
    /// 人员信息
    /// </summary>
    public class EmpInfoDto
    {
        /// <summary>
        /// 人员工号
        /// </summary>
        [JsonProperty("emplid")]
        public string EmployId { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [JsonProperty("birthdate")]
        public string Birthdate { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [JsonProperty("national_id")]
        public string Nationalid { get; set; }
    }
}
