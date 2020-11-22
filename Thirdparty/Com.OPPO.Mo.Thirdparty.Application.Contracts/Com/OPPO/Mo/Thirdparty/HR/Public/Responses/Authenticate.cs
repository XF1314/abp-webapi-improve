using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Responses
{
    public class Authenticate
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string Employid { get; set; }
        /// <summary>
        /// 工作职能
        /// </summary>
        public string JobFunction { get; set; }
        /// <summary>
        /// 职能描述
        /// </summary>
        public string FunctionDesc { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime BeginDate { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string CStatus { get; set; }
        /// <summary>
        /// 评估等级
        /// </summary>
        public string CRateLvl { get; set; }
        /// <summary>
        /// 评估职级
        /// </summary>
        public string CRateRank { get; set; }
        /// <summary>
        /// 记分
        /// </summary>
        public string Score { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string CRemark { get; set; }
    }
}
