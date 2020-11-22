using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{
    public class TransferEmployeeQueryDto
    {
        /// <summary>
        /// 员工ID,必填
        /// </summary>
       [Required]
        public string EmployeeId { get; set; }

        /// <summary>
        /// 雇佣记录编号,必填
        /// </summary>
        [Required]
        public int EmploymentRecord { get; set; }
    }
}
