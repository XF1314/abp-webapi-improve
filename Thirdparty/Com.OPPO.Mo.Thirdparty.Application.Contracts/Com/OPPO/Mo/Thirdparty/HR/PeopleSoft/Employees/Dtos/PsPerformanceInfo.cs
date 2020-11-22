using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 绩效信息
    /// </summary>
    public class PsPerformanceInfo
    {
        public PsPerformanceInfo()
        {
            Records = new List<PerformanceInfo>();
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        /// <summary>
        /// 绩效信息
        /// </summary>
        [JsonProperty("records")]
        public List<PerformanceInfo> Records { get; set; }
    }

    public class PerformanceInfo
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        [JsonProperty("emplid")]
        public string EmplId { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [JsonProperty("effdt")]
        public DateTime? EffDateTime { get; set; }

     
        /// <summary>
        /// 年份
        /// </summary>
        [JsonProperty("YEAR")]
        public string Year { get; set; }

        /// <summary>
        /// 等级类型
        /// </summary>
        [JsonProperty("c_rate_type")]
        public string RateType { get; set; }

        /// <summary>
        /// 等级结果
        /// </summary>
        [JsonProperty("c_rate_rslt")]
        public string RateRslt { get; set; }
    }
}
