using Com.OPPO.Mo.Thirdparty.HR.PreEmploymentPlatform.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Response
{

    public class EmployDataResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public long Datetime { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 简历信息
        /// </summary>
        public List<ResumeInfo> Data { get; set; }
    }

    public class Employ
    {
        /// <summary>
        /// 教育背景
        /// </summary>
        public List<EducationItem> education { get; set; }
        /// <summary>
        /// 评价
        /// </summary>
        public string evaluate { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string femail { get; set; }
        /// <summary>
        /// ID
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
        /// 推荐人工号
        /// </summary>
        public string recommenderEmpno { get; set; }
        /// <summary>
        /// 与推荐人关系
        /// </summary>
        public string recommenderRelationship { get; set; }
        /// <summary>
        /// 招聘渠道
        /// </summary>
        public string recruitChannel { get; set; }
        /// <summary>
        /// 职业历程
        /// </summary>
        public List<WorkItem> work { get; set; }
        ///// <summary>
        ///// 教育背景
        ///// </summary>
        //public List<EducationBackgroupList> educationBackgroup { get; set; }
        ///// <summary>
        ///// 职业历程
        ///// </summary>
        //public List<WorkExperienceList> workExperience { get; set; }
        /// <summary>
        /// 面试官
        /// </summary>
        public string interviewe { get; set; }
        /// <summary>
        /// 评价
        /// </summary>
        public string appraise { get; set; }
        /// <summary>
        /// HR面试官
        /// </summary>
        public string hrinterviewe { get; set; }
        /// <summary>
        /// HR评价
        /// </summary>
        public string hrappraise { get; set; }


    }

    public class EducationBackgroupList
    {
        /// <summary>
        /// 
        /// </summary>
        public string eNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string eBeginDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string eEndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string eSchool { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string eMajor { get; set; }
        /// <summary>
        /// 大专_大专
        /// </summary>
        public string eEducation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string eRemark { get; set; }
    }

    public class WorkExperienceList
    {
        /// <summary>
        /// 
        /// </summary>
        public string wNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wBeginDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wEndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wCompany { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wJob { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wRemark { get; set; }
    }

    public class EducationItem
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int fsort { get; set; }
        /// <summary>
        /// 教育背景-学历
        /// </summary>
        public string fdiploma { get; set; }
        /// <summary>
        /// 教育背景-结束时间
        /// </summary>
        public string fendTime { get; set; }
        /// <summary>
        /// 教育背景-专业
        /// </summary>
        public string fmajor { get; set; }
        /// <summary>
        /// 教育背景-备注        
        /// </summary>
        public string fmajorDescription { get; set; }
        /// <summary>
        /// 教育背景-学校
        /// </summary>
        public string fschoolname { get; set; }
        /// <summary>
        /// 教育背景-开始时间
        /// </summary>
        public string fstartTime { get; set; }
    }

    public class WorkItem
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int fsort { get; set; }
        /// <summary>
        /// 职业历程-企业名称
        /// </summary>
        public string fcompanyname { get; set; }
        /// <summary>
        /// 职业历程-结束时间
        /// </summary>
        public string fendTime { get; set; }
        /// <summary>
        /// 职业历程-职位名称
        /// </summary>
        public string fjobtitle { get; set; }
        /// <summary>
        /// 职业历程-开始时间
        /// </summary>
        public string fstartTime { get; set; }
        /// <summary>
        /// 职业历程-备注
        /// </summary>
        public string jobDescription { get; set; }
    }

}
