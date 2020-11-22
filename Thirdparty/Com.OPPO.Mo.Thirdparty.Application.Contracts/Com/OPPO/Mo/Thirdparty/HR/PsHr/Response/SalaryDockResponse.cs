using Com.OPPO.Mo.Thirdparty.HR.PsHr.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response
{
    public class SalaryDockResponse: EsbResponseBody
    {
        public List<SalaryDockResultsDto> data { get; set; }
    }

    public class SalaryDockResults
    {
        /// <summary>
        /// 单号
        /// </summary>
        public string FileNo { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
        public string  EmployId { get; set; }
        /// <summary>
        /// 处理状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 处理返回信息
        /// </summary>
        public string Describe { get; set; }
        
    }
}
