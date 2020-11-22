using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Dto
{
    public class BaseUserInfoDto
    {
        /// <summary>
        /// 类型，0员工，1访客，2vip，3黄名单
        /// </summary>
        public int SubjectType { get; set; }

        /// <summary>
        /// 类型，0员工，1访客，2vip，3黄名单
        /// </summary>
        public DateTime CreateDate { get; set; }

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
        public DateTime EntryDate { get; set; }

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
        public DateTime StartTime { get; set; }

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
        public DateTime Birthday { get; set; }


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
        public DateTime EndTime { get; set; }
    }
}
