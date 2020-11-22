
using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Request;
using Com.OPPO.Mo.Thirdparty.HR.PreEmploymentPlatform.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Dtos
{

    public class EmploymentDto
    {
        /// <summary>
        /// 职级ID（职级没有ID，直接就是level，比如说14）
        /// </summary>
        [Required]
        public string RankId { get; set; }
        /// <summary>
        /// 职级描述
        /// </summary>
        [Required]
        public string RankName { get; set; }

        /// <summary>
        /// 国家码（+86）
        /// </summary>
        [Required]
        public string CountryCode { get; set; }

        /// <summary>
        /// （流程的文件编号）
        /// </summary>
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// 中文姓名（发起时录入中文名称）
        /// </summary>
        [Required]
        public string ChinsesName { get; set; }

        /// <summary>
        /// 证件号码（身份证号、港澳通行证等）
        /// </summary>
        [Required]
        public string CardNumber { get; set; }

        /// <summary>
        /// 组别ID（已添加，但是要最新发起的流程才能有）
        /// </summary>
        [Required]
        public string TeamId { get; set; }

        /// <summary>
        /// 系统ID（已添加，但是要最新发起的流程才能有）
        /// </summary>
        [Required]
        public string SysId { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的IT（不知道，无）
        /// </summary>
        public string ItName { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的主管员（可以根据部门编码获取，但是如果有多个如何传递，我们建议因为逗号隔开即可)
        /// </summary>
        [Required]
        public string ChargeName { get; set; }
        /// <summary>
        /// 待入职员工所在部门对应的IT（不知道，无）
        /// </summary>
        public string ItId { get; set; }

        /// <summary>
        /// 招聘经理id（只能是流程的发起人，没有单独保存这个信息）
        /// </summary>
        [Required]
        public string ManagerId { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的主管员（可以根据部门编码获取，但是如果有多个如何传递，我们建议因为逗号隔开即可)
        /// </summary>
        [Required]
        public string ChargeId { get; set; }

        /// <summary>
        ///系统名称
        /// </summary>
        [Required]
        public string SysName { get; set; }
        /// <summary>
        /// 手机号码（涉及到非大陆，不能校验手机号码，但是有联系号码）
        /// </summary>
        [Required]
        public string Telphone { get; set; }

        /// <summary>
        /// 报道地点(存在，统一传中文名称）
        /// </summary>
        [Required]
        public string CoverAddress { get; set; }

        /// <summary>
        /// 教育经历（时间精确到年月，没有日）
        /// </summary>
        [Required]
        public List<EducationInfoDto> EduList { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
        public string Email { get; set; }


        /// <summary>
        /// 工作地点(存在，统一传中文名称）(修改)工作地点拆分为（国家-城市-地点）
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///证件类型（有证件类型编码，PS提供）
        /// </summary>
        [Required]
        public string CardType { get; set; }

        /// <summary>
        /// 竞业状态（新增版本新增，传递待定）
        /// </summary>
        public string WorkingCondition { get; set; }

        /// <summary>
        /// 性别(1：男，2：女)
        /// </summary>
        [Required]
        public int Sex { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        [Required]
        public string PositionName { get; set; }

        /// <summary>
        ///部门name
        /// </summary>
        [Required]
        public string DeptName { get; set; }

        /// <summary>
        ///组别名称
        /// </summary>
        [Required]
        public string TeamName { get; set; }
        /// <summary>
        /// 待入职员工所在部门对应的文员（可以根据部门编码获取，但是如果有多个如何传递，我们建议因为逗号隔开即可)
        /// </summary>
        [Required]
        public string OfficerName { get; set; }

        /// <summary>
        /// 工作经历（时间精确到年月，没有日,存在非日期格式，比如“至今”）
        /// </summary>
        [Required]
        public List<WorkInfoDto> WorkList { get; set; }

        /// <summary>
        /// 招聘经理姓名（只能是流程的发起人，没有单独保存这个信息）
        /// </summary>
        [Required]
        public string ManagerName { get; set; }

        /// <summary>
        /// 英文名称（暂无）
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的文员（可以根据部门编码获取，但是如果有多个如何传递，我们建议因为逗号隔开即可)
        /// </summary>
        [Required]
        public string OfficerId { get; set; }

        /// <summary>
        /// system_sign  新增，oppo/马里亚纳系统标识（OPP10/M20）
        /// </summary>
        [Required]
        public string SystemSign { get; set; }

        /// <summary>
        /// 拟入职日期，2019-10-10，也就是报到日期(存在，统一传中文名称）
        /// </summary>
        [Required]
        public DateTime PlaneDate { get; set; }

        /// <summary>
        ///待入职员工所在部门对应的BP（不知道，无）
        /// </summary>
        public string BpName { get; set; }

        /// <summary>
        /// 待入职员工所在部门对应的BP（不知道，无）
        /// </summary>
        public string BpId { get; set; }

        /// <summary>
        /// 部门ID（已添加，但是要最新发起的流程才能有）
        /// </summary>
        [Required]
        public string DeptId { get; set; }

        /// <summary>
        /// 岗位ID（已添加，但是要最新发起的流程才能有）
        /// </summary>
        [Required]
        public string PositionId { get; set; }

        /// <summary>
        /// 工作地点国家id(新增)
        /// </summary>
        [Required]
        public string WorkCountryId { get; set; }

        /// <summary>
        /// 工作地点城市id(新增)
        /// </summary>
        [Required]
        public string WorkCityId { get; set; }

        /// <summary>
        /// 工作地点地点id(新增)
        /// </summary>
        [Required]
        public string WorkPlaceId { get; set; }

        /// <summary>
        /// 工作地点国家名称(新增)
        /// </summary>
        [Required]
        public string WorkCountryName { get; set; }

        /// <summary>
        /// 工作地点城市名称(新增)
        /// </summary>
        [Required]
        public string WorkCityName { get; set; }

        /// <summary>
        /// 工作地点地点名称(新增)
        /// </summary>
        [Required]
        public string WorkPlaceName { get; set; }

    }
}
