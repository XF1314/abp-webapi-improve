using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Request
{
    public class OvertimePush
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; set; }
        /// <summary>
        /// 加班月份
        /// </summary>
        [JsonProperty("c_month")]
        public string OvertimeMonth { get; set; }
        /// <summary>
        /// 加班日期
        /// </summary>
        [JsonProperty("c_date")]
        public string OvertimeDate { get; set; }
        /// <summary>
        /// 普通加班工时
        /// </summary>
        [JsonProperty("c_wh_a")]
        public float Normal { get; set; }
        /// <summary>
        /// 工作日加班工时
        /// </summary>
        [JsonProperty("c_wh_b")]
        public float Workday { get; set; }
        /// <summary>
        /// 周末加班工时
        /// </summary>
        [JsonProperty("c_wh_c")]
        public float Weekend { get; set; }
        /// <summary>
        /// 法定节假日加班工时
        /// </summary>
        [JsonProperty("c_wh_d")]
        public float Holiday { get; set; }
        /// <summary>
        /// 加班事由
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}
