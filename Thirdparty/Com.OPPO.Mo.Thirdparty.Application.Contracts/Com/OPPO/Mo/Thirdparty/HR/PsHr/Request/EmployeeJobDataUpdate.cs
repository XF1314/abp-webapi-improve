using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class EmployeeJobDataUpdate
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

        /// <summary>
        /// 操作日期,必填
        /// </summary>
        [JsonProperty("hhrActionDate")]
        public string ActionDate { get; set; }
        /// <summary>
        /// 操作,必填
        /// </summary>
        [JsonProperty("hhrAction")]
        public string Action { get; set; }
        /// <summary>
        /// 操作原因,非必填
        /// </summary>
        [JsonProperty("hhrActionReason")]
        public string EmployActionReasoneeId { get; set; }
        /// <summary>
        /// 转正日期,非必填
        /// </summary>
        [JsonProperty("hhrProbationDate")]
        public string ProbationDate { get; set; }
        /// <summary>
        /// 业务单位（集合ID）,必填
        /// </summary>
        [JsonProperty("hhrBusUnit")]
        public string BusinessUnit { get; set; }
        /// <summary>
        /// 部门ID,必填
        /// </summary>
        [JsonProperty("hhrDeptId")]
        public string DepartmentId { get; set; }
        /// <summary>
        /// 岗位代码,必填
        /// </summary>
        [JsonProperty("hhrJobCode")]
        public string JobCode { get; set; }
        /// <summary>
        /// 国家/地区,必填
        /// </summary>
        [JsonProperty("hhrCountry")]
        public string Country { get; set; }
        /// <summary>
        /// 工作城市,必填
        /// </summary>
        [JsonProperty("hhrLocation")]
        public string Location { get; set; }
        /// <summary>
        /// 办公地点,非必填
        /// </summary>
        [JsonProperty("hhrOffcLocn")]
        public string OfficeLocation { get; set; }

        /// <summary>
        /// 职级,非必填
        /// </summary>
        [JsonProperty("hhrSupLvlId")]
        public string RankId { get; set; }
        /// <summary>
        /// 员工类别,非必填
        /// </summary>
        [JsonProperty("hhrEmplClass")]
        public string EmployeeClass { get; set; }
    }
}
