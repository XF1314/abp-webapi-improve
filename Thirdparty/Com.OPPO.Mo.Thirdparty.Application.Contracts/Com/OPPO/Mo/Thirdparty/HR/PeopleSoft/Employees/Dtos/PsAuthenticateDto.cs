using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 认证信息输出类
    /// </summary>
    public class PsAuthenticateDto
    {
        public PsAuthenticateDto()
        {
            Records = new List<RecordDto>();
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// 记录信息
        /// </summary>
        public List<RecordDto> Records { get; set; }
    }

    public class RecordDto
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        public string EmplId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string JobFunction { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string FunctionDesc { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public DateTime? BgnDateTime { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string CStatus { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string RateLvl { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string RateRank { get; set; }

        /// <summary>
        /// 成绩
        /// </summary>
        public string Score { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
