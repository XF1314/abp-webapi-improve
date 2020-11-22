using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.PS.Dtos
{
    public class OnePlusHolidayOTDto
    {
        /// <summary>
        /// 工号
        /// </summary>
        [Required]
        public string EmpId { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        [Required]
        public string FormInstanceCode { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        [Required]
        public string BeginDt { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        [Required]
        public string EndDt { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Required]
        public string BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Required]
        public string EndTime { get; set; }
        /// <summary>
        /// 加班总天数
        /// </summary>
        [Required]
        public string COt3Days { get; set; }
    }
}
