using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos
{

    public class AuthenticateDto
    {
        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty("emplid")] 
        public string Employid { get; set; }
        /// <summary>
        /// 工作职能
        /// </summary>
        [JsonProperty("job_function")] 
        public string JobFunction { get; set; }
        /// <summary>
        /// 职能描述
        /// </summary>
        [JsonProperty("function_desc")] 
        public string FunctionDesc { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        [JsonProperty("bgn_dt")] 
        public DateTime BeginDate { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("status")] 
        public string Status { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("c_status")] 
        public string CStatus { get; set; }
        /// <summary>
        /// 评估等级
        /// </summary>
        [JsonProperty("c_rate_lvl")] 
        public string CRateLvl { get; set; }
        /// <summary>
        /// 评估职级
        /// </summary>
        [JsonProperty("c_rate_rank")]
        public string CRateRank { get; set; }
        /// <summary>
        /// 记分
        /// </summary>
        [JsonProperty("score")] 
        public string Score { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("c_remark")] 
        public string CRemark { get; set; }
    }

}
