using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PreEmploymentPlatform.Dtos
{

    public class WorkInfoDto
    {
        /// <summary>
        /// 工作开始日期,例如2020-10-09
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 工作结束日期，例如2023-10-01
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        public string Position { get; set; }
    }
}
