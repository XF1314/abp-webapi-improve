using Com.OPPO.Mo.Thirdparty.Megvii.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Dto
{
    //: BaseUserInfo
    public class CreateUserResponseDto
    {
        /// <summary>
        /// 类型，0员工，1访客，2vip，3黄名单
        /// </summary>
        [JsonProperty("subject_type")]
        public int SubjectType { get; set; }

        /// <summary>
        /// 创建时间戳
        /// </summary>
        [JsonProperty("create_time")]
        public long? CreateDate { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty("job_number")]
        public string JobNumber { get; set; }


        /// <summary>
        /// 访客类型1访客， 2vip访客
        /// </summary>
        [JsonProperty("visitor_type")]
        public int VisitorType { get; set; }


        /// <summary>
        /// 职位
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }


        /// <summary>
        /// 入职日期
        /// </summary>
        [JsonProperty("entry_date")]
        public long? EntryDate { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [JsonProperty("department")]
        public string Department { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// 头像，图像base64编码
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 访客开始时间
        /// </summary>
        [JsonProperty("start_time")]
        public long? StartTime { get; set; }

        /// <summary>
        /// 访问人
        /// </summary>
        [JsonProperty("interviewee")]
        public string Visitors { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [JsonProperty("birthday")]
        public long? Birthday { get; set; }

        /// <summary>
        /// 来访目的
        /// </summary>
        [JsonProperty("purpose")]
        public int Purpose { get; set; }

        /// <summary>
        /// 来自，用于访客
        /// </summary>
        [JsonProperty("come_from")]
        public string ComeFrom { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
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
        public long? EndTime { get; set; }

        /// <summary>
        /// 姓名拼音
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// 密码是否重置
        /// </summary>
        [JsonProperty("password_reseted")]
        public bool PasswordReseted { get; set; }

        /// <summary>
        /// 公司id
        /// </summary>
        [JsonProperty("company_id")]
        public int CompanyId { get; set; }

        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 访问通知
        /// </summary>
        [JsonProperty("visit_notify")]
        public bool VisitNotify { get; set; }

        /// <summary>
        /// 底库id列表
        /// </summary>
        [JsonProperty("photos")]
        public List<PhotoInfoDto> Photos { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        /// <summary>
        /// 访问人姓名拼音
        /// </summary>
        [JsonProperty("interviewee_pinyin")]
        public string IntervieweePinyin { get; set; }
    }

    public class PhotoInfoDto
    {
        /// <summary>
        /// 图片地址	
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// subject_id
        /// </summary>
        [JsonProperty("subject_id")]
        public int SubjectId { get; set; }
        /// <summary>
        /// 公司id
        /// </summary>
        [JsonProperty("company_id")]
        public int CompanyId { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// 质量
        /// </summary>
        public int Quality { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }

    public class Group
    {
        /// <summary>
        /// 组名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 组id
        /// </summary>
        public int Id { get; set; }
    }

}
