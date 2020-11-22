using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Request
{
    public class LeaveUpdate
    {
        /// <summary>
        /// 文件编号
        /// </summary>
          [JsonProperty("hhrInstanceId")]
        public string FormInstanceCode { get; set; }
        /// <summary>
        /// 销假时间
        /// </summary>
          [JsonProperty("hhrApprovalDate")]
          [JsonConverter(typeof(DateStringConverter))]
        public DateTime ApprovalDate { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
          [JsonProperty("hhrEmplid")]
        public string EmployeeId { get; set; }
        /// <summary>
        /// 与请假是否相符Y/N
        /// </summary>
          [JsonProperty("hhrFlag")]
        public string IsLeaveTrue { get; set; }
        /// <summary>
        /// 是否有销假资料Y/N
        /// </summary>
          [JsonProperty("hhrFlag1")]
        public string IsFile { get; set; }
    }
}
