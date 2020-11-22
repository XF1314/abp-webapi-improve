using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class TransferEmployeeQuery
    {
        /// <summary>
        /// 员工ID,必填
        /// </summary>
        [JsonProperty("hhrEmplid")]
        public string EmployeeId { get; set; }

        /// <summary>
        /// 雇佣记录编号,必填
        /// </summary>
        [JsonProperty("hhrEmplRcd")]
        public int EmploymentRecord { get; set; }
    }
}
