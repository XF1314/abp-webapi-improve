using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Request
{

    public class SalaryInfo
    {

        /// <summary>
        /// 单号
        /// </summary>
        [JsonProperty("FILENO")]
        public string FileNo { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
        [JsonProperty("EMPLID")]
        public string EmployId { get; set; }
        /// <summary>
        /// 试用期绩效奖金
        /// </summary>
        [JsonProperty("PREMB1")]
        public string ProbationBonus { get; set; }
        /// <summary>
        /// 转正后绩效奖金
        /// </summary>
        [JsonProperty("PREMB2")]
        public string FormalBonus { get; set; }
        /// <summary>
        /// 试用期月薪
        /// </summary>
        [JsonProperty("PAYCT1")]
        public string ProbationMonthSalary { get; set; }
        /// <summary>
        /// 转正月薪
        /// </summary>
        [JsonProperty("PAYCT2")]
        public string FormalMonthSalary { get; set; }
        /// <summary>
        /// 薪酬发放模式YX/GS
        /// </summary>
        [JsonProperty("GROUP")]
        public string PaymentType { get; set; }
    }
}
