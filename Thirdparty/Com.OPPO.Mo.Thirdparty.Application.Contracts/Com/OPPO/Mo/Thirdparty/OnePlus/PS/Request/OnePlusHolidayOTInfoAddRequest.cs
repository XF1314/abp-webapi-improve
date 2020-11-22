using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.PS.Request
{
    public class OnePlusHolidayOTInfoAddRequest : BaseEsbRequest
    {
       public string lines { get; set; }
    }

    /// <summary>
    /// 节假日加班信息
    /// </summary>
    public class OTDataInfo
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        [JsonProperty("emplId")]
        public string EmpId { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        [JsonProperty("beginDt")]
        public string BeginDt { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [JsonProperty("beginTime")]
        public string BeginTime { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        [JsonProperty("endDt")]
        public string EndDt { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [JsonProperty("endTime")]
        public string EndTime { get; set; }
        /// <summary>
        /// 加班总天数
        /// </summary>
        [JsonProperty("cOt3Days")]
        public string COt3Days { get; set; }
    }
}
