using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Request
{
    public class DepartmentEmploy
    {
        /// <summary>
        /// 部门id
        /// </summary>
        [JsonProperty("deptid")]
        public string DepartmentId { get; set; }

        /// <summary>
        /// 员工ID
        /// </summary>
        [JsonProperty("emplid")]
        public string EmployId { get; set; }
    }
}
