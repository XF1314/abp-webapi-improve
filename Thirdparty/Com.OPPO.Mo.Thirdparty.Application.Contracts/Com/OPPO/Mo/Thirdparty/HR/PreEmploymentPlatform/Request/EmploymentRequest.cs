using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Request
{

    public class EducationInfo
    {
        /// <summary>
        /// 教育开始时间
        /// </summary>
         [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 教育结束时间
        /// </summary>
         [JsonProperty("end_date")] 
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
         [JsonProperty("school")] 
        public string School { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
         [JsonProperty("education")] 
        public string Education { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
         [JsonProperty("fmajor")]
        public string Major { get; set; }
    }

    public class WorkInfo
    {
        /// <summary>
        /// 工作开始日期,例如2020-10-09
        /// </summary>
         [JsonProperty("start_date")] 
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 工作结束日期，例如2023-10-01
        /// </summary>
         [JsonProperty("end_date")] 
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
         [JsonProperty("company")] 
        public string Company { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
         [JsonProperty("position")] 
        public string Position { get; set; }
    }

    public class EmploymentRequest: BaseEsbRequest
    {
        /// <summary>
        /// 职级ID（职级没有ID，直接就是level，比如说14）
        /// </summary>
         [JsonProperty("rank_id")] 
        public string RankId { get; set; }
        /// <summary>
        /// 职级描述
        /// </summary>
         [JsonProperty("rank_name")] 
        public string RankName { get; set; }

        /// <summary>
        /// 国家码（+86）
        /// </summary>
         [JsonProperty("countrycode")] 
        public string CountryCode { get; set; }

        /// <summary>
        /// （流程的文件编号）
        /// </summary>
         [JsonProperty("mo_number")] 
        public string Number { get; set; }

        /// <summary>
        /// 中文姓名（发起时录入中文名称）
        /// </summary>
         [JsonProperty("cname")] 
        public string ChinsesName { get; set; }

        /// <summary>
        /// 证件号码（身份证号、港澳通行证等）
        /// </summary>
         [JsonProperty("fidcard")] 
        public string CardNumber { get; set; }

        /// <summary>
        /// 组别ID（已添加，但是要最新发起的流程才能有）
        /// </summary>
         [JsonProperty("team_id")]
        public string TeamId { get; set; }

        /// <summary>
        /// 系统ID（已添加，但是要最新发起的流程才能有）
        /// </summary>
         [JsonProperty("sys_id")]
        public string SysId { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的IT（不知道，无）
        /// </summary>
         [JsonProperty("it_name")]
        public string ItName { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的主管员（可以根据部门编码获取，但是如果有多个如何传递，我们建议因为逗号隔开即可)
        /// </summary>
         [JsonProperty("charge_name")] 
        public string ChargeName { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的IT（不知道，无）
        /// </summary>
         [JsonProperty("it_id")] 
        public string ItId { get; set; }

        /// <summary>
        /// 招聘经理id（只能是流程的发起人，没有单独保存这个信息）
        /// </summary>
         [JsonProperty("manager_id")] 
        public string ManagerId { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的主管员（可以根据部门编码获取，但是如果有多个如何传递，我们建议因为逗号隔开即可)
        /// </summary>
         [JsonProperty("charge_id")] 
        public string ChargeId { get; set; }

        /// <summary>
        ///系统名称
        /// </summary>
         [JsonProperty("sys_name")] 
        public string SysName { get; set; }
        /// <summary>
        /// 手机号码（涉及到非大陆，不能校验手机号码，但是有联系号码）
        /// </summary>
         [JsonProperty("tel")]
        public string Telphone { get; set; }

        /// <summary>
        /// 报道地点(存在，统一传中文名称）
        /// </summary>
         [JsonProperty("cover_address")] 
        public string CoverAddress { get; set; }

        /// <summary>
        /// 教育经历（时间精确到年月，没有日）
        /// </summary>
        [JsonProperty("edu_list")]
        public string EduList { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
         [JsonProperty("email")]
        public string Email { get; set; }


        /// <summary>
        /// 工作地点(存在，统一传中文名称）(修改)工作地点拆分为（国家-城市-地点）
        /// </summary>
         [JsonProperty("address")] 
        public string Address { get; set; }

        /// <summary>
        ///证件类型（有证件类型编码，PS提供）
        /// </summary>
         [JsonProperty("fcardtype")] 
        public string CardType { get; set; }

        /// <summary>
        /// 竞业状态（新增版本新增，传递待定）
        /// </summary>
         [JsonProperty("fprotect")] 
        public string WorkingCondition { get; set; }

        /// <summary>
        /// 性别(1：男，2：女)
        /// </summary>
        [JsonProperty("sex")] 
        public int Sex { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
         [JsonProperty("position_name")]
        public string PositionName { get; set; }

        /// <summary>
        ///部门name
        /// </summary>
         [JsonProperty("dept_name")]
        public string DeptName { get; set; }

        /// <summary>
        ///组别名称
        /// </summary>
         [JsonProperty("team_name")] 
        public string TeamName { get; set; }
        /// <summary>
        /// 待入职员工所在部门对应的文员（可以根据部门编码获取，但是如果有多个如何传递，我们建议因为逗号隔开即可)
        /// </summary>   
         [JsonProperty("officer_name")]
        public string OfficerName { get; set; }

        /// <summary>
        /// 工作经历（时间精确到年月，没有日,存在非日期格式，比如“至今”）
        /// </summary>
        [JsonProperty("work_list")]
        public string WorkList { get; set; }

        /// <summary>
        /// 招聘经理姓名（只能是流程的发起人，没有单独保存这个信息）
        /// </summary>
         [JsonProperty("manager_name")] 
        public string ManagerName { get; set; }

        /// <summary>
        /// 英文名称（暂无）
        /// </summary>
         [JsonProperty("ename")] 
        public string EnglishName { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的文员（
        /// 可以根据部门编码获取，但是如果有多个如何传递，我们建议因为逗号隔开即可)
        /// </summary>
         [JsonProperty("officer_id")] 
        public string OfficerId { get; set; }

        /// <summary>
        /// system_sign  新增，oppo/马里亚纳系统标识（OPP10/M20）
        /// </summary>
         [JsonProperty("system_sign")] 
        public string SystemSign { get; set; }

        /// <summary>
        /// 拟入职日期，2019-10-10，也就是报到日期(存在，统一传中文名称）
        /// </summary>
        [JsonProperty("plane_date")] 
        public DateTime PlaneDate { get; set; }

        /// <summary>
        ///待入职员工所在部门对应的BP（不知道，无）
        /// </summary>
         [JsonProperty("bp_name")]
        public string BpName { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的BP（不知道，无）
        /// </summary>
         [JsonProperty("bp_id")] 
        public string BpId { get; set; }

        /// <summary>
        /// 部门ID（已添加，但是要最新发起的流程才能有）
        /// </summary>
         [JsonProperty("dept_id")] 
        public string DeptId { get; set; }

        /// <summary>
        /// 岗位ID（已添加，但是要最新发起的流程才能有）
        /// </summary>
         [JsonProperty("position_id")] 
        public string PositionId { get; set; }

        /// <summary>
        /// 工作地点国家id(新增)
        /// </summary>
         [JsonProperty("work_country_id")] 
        public string WorkCountryId { get; set; }

        /// <summary>
        /// 工作地点城市id(新增)
        /// </summary>
         [JsonProperty("work_city_id")] 
        public string WorkCityId { get; set; }

        /// <summary>
        /// 工作地点地点id(新增)
        /// </summary>
         [JsonProperty("work_place_id")] 
        public string WorkPlaceId { get; set; }

        /// <summary>
        /// 工作地点国家名称(新增)
        /// </summary>     
         [JsonProperty("work_country_name")] 
        public string WorkCountryName { get; set; }

        /// <summary>
        /// 工作地点城市名称(新增)
        /// </summary>
         [JsonProperty("work_city_name")] 
        public string WorkCityName { get; set; }

        /// <summary>
        /// 工作地点地点名称(新增)
        /// </summary>
         [JsonProperty("work_place_name")] 
        public string WorkPlaceName { get; set; }

    }


}
