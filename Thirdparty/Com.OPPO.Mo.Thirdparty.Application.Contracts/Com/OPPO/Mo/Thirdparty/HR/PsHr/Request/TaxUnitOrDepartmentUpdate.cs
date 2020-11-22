using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class TaxUnitOrDepartmentUpdate
    {
        /// <summary>
        /// 员工ID,必填
        /// </summary>
        [JsonProperty("hhrEmplid")]
        public string EmployeeId { get; set; }
        /// <summary>
        /// 生效日期,必填
        /// </summary>
        [JsonProperty("hhrEffdt")]
        public string EffectiveDate { get; set; }

        /// <summary>
        /// 操作类型,必填
        /// </summary>
        [JsonProperty("hhrAction")]
        public string ActionType { get; set; }
        /// <summary>
        /// 纳税单位编码,必填
        /// </summary>
        [JsonProperty("hhrCompany")]
        public string TaxUnit { get; set; }

        /// <summary>
        /// 纳税部门,必填
        /// </summary>
        [JsonProperty("hhrTaxDept")]
        public string TaxDepartment { get; set; }

    }
}
