using Com.OPPO.Mo.Thirdparty.Megvii.Dto;
using Com.OPPO.Mo.Thirdparty.Megvii.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Response
{
    //: BaseUserInfoDto
    public class CreateUserResponse
    {
         /// <summary>
        /// 类型，0员工，1访客，2vip，3黄名单
        /// </summary>
        public int SubjectType { get; set; }

        /// <summary>
        /// 类型，0员工，1访客，2vip，3黄名单
        /// </summary>
        public long? CreateDate { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string JobNumber { get; set; }


        /// <summary>
        /// 访客类型1访客， 2vip访客
        /// </summary>
        public int VisitorType { get; set; }


        /// <summary>
        /// 职位
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// 入职日期
        /// </summary>
        public long? EntryDate { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

     

        /// <summary>
        /// 头像，图像base64编码
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 访客开始时间
        /// </summary>
        public long? StartTime { get; set; }

        /// <summary>
        /// 访问人
        /// </summary>
        public string Visitors { get; set; }


        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public long? Birthday { get; set; }


        /// <summary>
        /// 来访目的
        /// </summary>
        public int Purpose { get; set; }

        /// <summary>
        /// 来自，用于访客
        /// </summary>
        public string ComeFrom { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别，0未知，1男，2女
        /// </summary>
        public int Gender { get; set; }


        /// <summary>
        /// 访客结束时间
        /// </summary>
        public long? EndTime { get; set; }

        /// <summary>
        /// 姓名拼音
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// 密码是否重置
        /// </summary>
        public bool PasswordReseted { get; set; }

        /// <summary>
        /// 公司id
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 访问通知
        /// </summary>
        public bool VisitNotify { get; set; }

        /// <summary>
        /// 底库id列表
        /// </summary>
        public List<PhotoInfo> Photos { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public List<Group> Groups { get; set; }

        /// <summary>
        /// 访问人姓名拼音
        /// </summary>
        public string IntervieweePinyin { get; set; }
    }

    public class PhotoInfo
    {
        /// <summary>
        /// 图片地址	
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// subject_id
        /// </summary>
        public int SubjectId { get; set; }
        /// <summary>
        /// 公司id
        /// </summary>
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

 
}
