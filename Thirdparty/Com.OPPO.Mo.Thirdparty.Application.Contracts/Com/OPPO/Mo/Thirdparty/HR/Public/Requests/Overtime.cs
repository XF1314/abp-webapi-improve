using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Request
{

    public class Overtime
    {
        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty("EMPLID")]
        public string EmployeeId { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [JsonProperty("BGN_DT")]
        public string BeginDate { get; set; }

        public string FLAG { get { return IsApprove ? "Y" : "N"; } }

        /// <summary>
        /// 是否审批,Y/N
        /// </summary>
        public bool IsApprove { get; set; }

        /// <summary>
        /// 加班天数
        /// </summary>
        [JsonProperty("DURATION_ABS")]
        public float OvertimeDays { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        [JsonProperty("APPROVE_DATE")]
        public string ApproveDate { get; set; }

    }

}
