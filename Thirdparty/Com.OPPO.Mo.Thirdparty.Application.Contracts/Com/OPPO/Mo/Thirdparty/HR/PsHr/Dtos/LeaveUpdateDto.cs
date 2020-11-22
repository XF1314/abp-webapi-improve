using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Dtos
{
    public class LeaveUpdateDto
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [Required]
        public string FormInstanceCode { get; set; }
        /// <summary>
        /// 销假时间
        /// </summary>
        [Required] 
        public DateTime ApprovalDate { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
        [Required] 
        public string EmployeeId { get; set; }
        /// <summary>
        /// 与请假是否相符Y/N
        /// </summary>
        [Required]
        public bool IsLeaveTrue { get; set; }
        /// <summary>
        /// 是否有销假资料Y/N
        /// </summary>
        [Required] 
        public bool IsFile { get; set; }
    }


}
