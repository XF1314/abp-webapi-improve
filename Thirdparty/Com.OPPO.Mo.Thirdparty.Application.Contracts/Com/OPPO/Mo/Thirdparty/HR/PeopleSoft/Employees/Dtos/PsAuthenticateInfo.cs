using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 认证信息
    /// </summary>
    public class PsAuthenticateInfo
    {
        public PsAuthenticateInfo()
        {
            Records = new List<RecordInfo>();
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        /// <summary>
        /// 记录信息
        /// </summary>
        [JsonProperty("records")]
        public List<RecordInfo> Records { get; set; }
    }

    public class RecordInfo
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        [JsonProperty("emplid")]
        public string EmplId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("job_function")]
        public string JobFunction { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("function_desc")]
        public string FunctionDesc { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("bgn_dt")]
        public DateTime? BgnDateTime { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("c_status")]
        public string CStatus { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("c_rate_lvl")]
        public string RateLvl { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("c_rate_rank")]
        public string RateRank { get; set; }

        /// <summary>
        /// 成绩
        /// </summary>
        [JsonProperty("score")]
        public string Score { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("c_remark")]
        public string Remark { get; set; }
    }
}
