using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{
    public class SalaryInfoDto
    {

        /// <summary>
        /// 单号
        /// </summary>
        public string FileNo { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
        public string EmployId { get; set; }
        /// <summary>
        /// 试用期绩效奖金
        /// </summary>
        public string ProbationBonus { get; set; }
        /// <summary>
        /// 转正后绩效奖金
        /// </summary>
        public string FormalBonus { get; set; }
        /// <summary>
        /// 试用期月薪
        /// </summary>
        public string ProbationMonthSalary { get; set; }
        /// <summary>
        /// 转正月薪
        /// </summary>
        public string FormalMonthSalary { get; set; }
        /// <summary>
        /// 薪酬发放模式YX/GS
        /// </summary>
        public string PaymentType { get; set; }
    }
}
