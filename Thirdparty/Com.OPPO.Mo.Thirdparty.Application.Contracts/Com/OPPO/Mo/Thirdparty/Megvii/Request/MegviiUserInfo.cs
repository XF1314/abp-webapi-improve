using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Request
{
    //: BaseUserInfo
    public class MegviiUserInfo
    {
        /// <summary>
        /// 类型，0员工，1访客，2vip，3黄名单
        /// </summary>
        [JsonProperty("subject_type")]
        public int SubjectType { get; set; }

        ///// <summary>
        ///// 底库id列表
        ///// </summary>
        //[MaxLength(256)]
        //[JsonProperty("photo_ids")]
        //public List<double> PhotoIds { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(64)]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty("job_number")]
        [MaxLength(64)]
        public string JobNumber { get; set; }

        /// <summary>
        /// 访客开始时间
        /// </summary>
        [JsonProperty("start_time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 访客结束时间
        /// </summary>
        [JsonProperty("end_time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 分组id
        /// </summary>
        [JsonProperty("group_ids")]
        public List<int> GroupIds { get; set; }

    }
}
