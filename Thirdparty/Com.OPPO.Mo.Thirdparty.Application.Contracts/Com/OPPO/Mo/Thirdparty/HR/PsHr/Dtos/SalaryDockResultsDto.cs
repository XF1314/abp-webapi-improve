using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Dtos
{
    public class SalaryDockResultsDto
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
        /// 处理状态
        /// </summary>
        [JsonProperty("STATUS")]
        public string Status { get; set; }
        /// <summary>
        /// 处理返回信息
        /// </summary>
        [JsonProperty("DESCR")]
        public string Describe { get; set; }

    }
}
