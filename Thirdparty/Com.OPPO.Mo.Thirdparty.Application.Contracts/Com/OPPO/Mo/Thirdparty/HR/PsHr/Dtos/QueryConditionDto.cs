using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Dtos
{
    public class QueryConditionDto
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string EmployeeId { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public string BeginDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 查询页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }
    }
}
