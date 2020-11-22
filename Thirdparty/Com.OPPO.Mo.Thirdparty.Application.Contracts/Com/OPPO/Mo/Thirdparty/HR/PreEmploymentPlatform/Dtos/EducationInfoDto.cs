using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PreEmploymentPlatform.Dtos
{

    public class EducationInfoDto
    {
        /// <summary>
        /// 教育开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 教育结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
        public string School { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string Major { get; set; }
    }
}
