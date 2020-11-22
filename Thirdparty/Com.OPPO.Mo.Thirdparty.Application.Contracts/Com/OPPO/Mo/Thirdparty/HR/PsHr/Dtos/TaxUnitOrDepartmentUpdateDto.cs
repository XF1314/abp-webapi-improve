using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{

    public class TaxUnitOrDepartmentUpdateDto
    {
        /// <summary>
        /// 员工ID,必填
        /// </summary>
       [Required]
        public string EmployeeId { get; set; }
        /// <summary>
        /// 生效日期,必填
        /// </summary>
        [Required]
        public string EffectiveDate { get; set; }

        /// <summary>
        /// 操作类型,必填
        /// </summary>
        [Required]
        public string ActionType { get; set; }
        /// <summary>
        /// 纳税单位编码,必填
        /// </summary>
        [Required]
        public string TaxUnit { get; set; }

        /// <summary>
        /// 纳税部门,必填
        /// </summary>
        [Required]
        public string TaxDepartment { get; set; }

    }
}
