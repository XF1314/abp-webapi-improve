using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Requests
{
    public class QueryCondition
    {
        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty("hhrEmplid")]
        public string EmployeeId { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [JsonProperty("hhrBeginDate")]
        public string BeginDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [JsonProperty("hhrEndDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// 查询页码
        /// </summary>
        [JsonProperty("hhrPageIndex")] 
        public int PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        [JsonProperty("hhrPageSize")]
        public int PageSize { get; set; }
    }
}
