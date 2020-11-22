using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Dto
{
    public class OvertimeDto
    {
        /// <summary>
        /// 工号
        /// </summary>
       [Required]
        public string EmployeeId { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [Required]
        public string BeginDate { get; set; }

        /// <summary>
        /// 是否审批
        /// </summary>
        [Required]
        public bool IsApprove { get; set; }

        /// <summary>
        /// 加班天数
        /// </summary>
        [Required]
        public float OvertimeDays { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        [Required]
        public string ApproveDate { get; set; }

    }
}
