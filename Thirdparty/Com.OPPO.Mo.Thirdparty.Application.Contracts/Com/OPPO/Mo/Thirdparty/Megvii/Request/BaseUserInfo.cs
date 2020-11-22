using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Request
{
    public class BaseUserInfo
    {
        /// <summary>
        /// 类型，0员工，1访客，2vip，3黄名单
        /// </summary>
        [JsonProperty("subject_type")]
        public int SubjectType { get; set; }

        /// <summary>
        /// 类型，0员工，1访客，2vip，3黄名单
        /// </summary>
        [JsonProperty("create_time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty("job_number")]
        [MaxLength(64)]
        public string JobNumber { get; set; }


        /// <summary>
        /// 访客类型1访客， 2vip访客
        /// </summary>
        [JsonProperty("visitor_type")]
        public int VisitorType { get; set; }


        /// <summary>
        /// 职位
        /// </summary>
        [MaxLength(64)]
        [JsonProperty("title")]
        public string Title { get; set; }


        /// <summary>
        /// 入职日期
        /// </summary>
        [JsonProperty("entry_date")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [MaxLength(256)]
        [JsonProperty("department")]
        public string Department { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(64)]
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// 头像，图像base64编码
        /// </summary>
        [MaxLength(256)]
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 访客开始时间
        /// </summary>
        [JsonProperty("start_time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 访问人
        /// </summary>
        [MaxLength(20)]
        [JsonProperty("interviewee")]
        public string Visitors { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(20)]
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [JsonConverter(typeof(DateTimeSecondConverter))]
        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 来访目的
        /// </summary>
        [JsonProperty("purpose")]
        public int Purpose { get; set; }

        /// <summary>
        /// 来自，用于访客
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("come_from")]
        public string ComeFrom { get; set; }

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
        /// 性别，0未知，1男，2女
        /// </summary>
        [JsonProperty("gender")]
        public int Gender { get; set; }

        /// <summary>
        /// 访客结束时间
        /// </summary>
        [JsonProperty("end_time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime EndTime { get; set; }

    }
}
