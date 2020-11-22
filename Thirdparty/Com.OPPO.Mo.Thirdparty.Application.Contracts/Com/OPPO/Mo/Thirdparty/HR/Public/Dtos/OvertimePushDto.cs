using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Dto
{
    public class OvertimePushDto
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        [Required]
        public string EmployeeId { get; set; }
        /// <summary>
        /// 加班月份
        /// </summary>
        [Required]
        public string OvertimeMonth { get; set; }
        /// <summary>
        /// 加班日期
        /// </summary>
        [Required]
        public string OvertimeDate { get; set; }
        /// <summary>
        /// 普通加班工时
        /// </summary>
        public float Normal { get; set; }
        /// <summary>
        /// 工作日加班工时
        /// </summary>
        public float Workday { get; set; }
        /// <summary>
        /// 周末加班工时
        /// </summary>
        public float Weekend { get; set; }
        /// <summary>
        /// 法定节假日加班工时
        /// </summary>
        public float Holiday { get; set; }
        /// <summary>
        /// 加班事由
        /// </summary>
        [Required]
        public string Comments { get; set; }
    }


}
