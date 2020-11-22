using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 绩效信息
    /// </summary>
    public class PsPerformanceDto
    {
        public PsPerformanceDto()
        {
            Records = new List<PerformanceDto>();
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// 绩效信息
        /// </summary>
        public List<PerformanceDto> Records { get; set; }
    }

    public class PerformanceDto
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        public string EmplId { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? EffDateTime { get; set; }


        /// <summary>
        /// 年份
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// 等级类型
        /// </summary>
        public string RateType { get; set; }

        /// <summary>
        /// 等级结果
        /// </summary>
        public string RateRslt { get; set; }
    }
}
