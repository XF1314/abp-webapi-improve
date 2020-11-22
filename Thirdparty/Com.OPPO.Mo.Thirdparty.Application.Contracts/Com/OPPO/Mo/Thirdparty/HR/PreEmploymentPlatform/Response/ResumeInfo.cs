using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PreEmploymentPlatform.Response
{
    /// <summary>
    /// 教育背景
    /// </summary>
    public class EducationItem
    {
        /// <summary>
        /// 学历
        /// </summary>
        public string fdiploma { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string fendTime { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string fmajor { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string fmajorDescription { get; set; }
        /// <summary>
        /// 学校
        /// </summary>
        public string fschoolname { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int fsort { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string fstartTime { get; set; }
    }

    /// <summary>
    /// 职业历程
    /// </summary>
    public class WorkItem
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string fcompanyname { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string fendTime { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string fjobtitle { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int fsort { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string fstartTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string jobDescription { get; set; }
    }

    /// <summary>
    /// 个人简历
    /// </summary>
    public class ResumeInfo
    {
        /// <summary>
        /// 评价
        /// </summary>
        public string appraise { get; set; }
        /// <summary>
        /// 教育背景
        /// </summary>
        public List<EducationItem> education { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string femail { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public string fid { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string fidnumber { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string fidtype { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string fname { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string fsex { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string ftel { get; set; }
        /// <summary>
        /// HR评价
        /// </summary>
        public string hrappraise { get; set; }
        /// <summary>
        /// HR面试官
        /// </summary>
        public string hrinterviewe { get; set; }
        /// <summary>
        /// 面试官
        /// </summary>
        public string interviewe { get; set; }
        /// <summary>
        /// 招聘渠道
        /// </summary>
        public string recruitChannel { get; set; }
        /// <summary>
        /// 职业历程
        /// </summary>
        public List<WorkItem> work { get; set; }
    }

    

}
