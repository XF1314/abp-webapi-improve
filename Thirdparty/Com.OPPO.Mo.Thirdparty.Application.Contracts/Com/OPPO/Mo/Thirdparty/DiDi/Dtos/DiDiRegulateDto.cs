using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Dtos
{
    /// <summary>
    /// 用车制度输出参数
    /// </summary>
    public class DiDiRegulateDto
    {
        /// <summary>
        /// 0表示成功，非0表示失败
        /// </summary>
        public int Errno { get; set; }

        /// <summary>
        /// errno=0时为常量"SUCCESS"，errno!=0时为错误信息
        /// </summary>
        public string Errmsg { get; set; }

        /// <summary>
        /// 制度列表信息
        /// </summary>
        public List<DiDiRegulationBodyDto> Body { get; set; }
    }

    /// <summary>
    /// 制度列表信息
    /// </summary>
    public class DiDiRegulationBodyDto
    {
        /// <summary>
        /// 员工在滴滴企业平台的ID
        /// </summary>
        public long MemberId { get; set; }

        /// <summary>
        /// 员工手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Realname { get; set; }

        /// <summary>
        /// 员工ID（员工在公司的员工号）
        /// </summary>
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 部门名称（老），后续此参数会去掉
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 所在分公司名称（老），后续此参数会去掉
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// 系统角色(0-车辆预定人员，1-普通管理员，2-超级管理员)
        /// </summary>
        public int SystemRole { get; set; }

        /// <summary>
        /// 常驻地中文
        /// </summary>
        public string Residentsname { get; set; }

        /// <summary>
        /// 角色，通过角色获取API
        /// </summary>
        public string RoleIds { get; set; }

        /// <summary>
        /// 是否企业支付余额（0-否，1-是）
        /// </summary>
        public int UseCompanyMoney { get; set; }

        /// <summary>
        /// 每月配额
        /// </summary>
        public string TotalQuota { get; set; }

        /// <summary>
        /// 叫车时备注信息是否必填(0-选填，1-必填，2-按制度填写)
        /// </summary>
        public int IsRemark { get; set; }

        /// <summary>
        /// 所在部门ID（新）
        /// </summary>
        public long BudgetCenterId { get; set; }

        /// <summary>
        /// 用车制度ID数组
        /// </summary>
        public List<string> RegulationId { get; set; }

        /// <summary>
        /// 所在项目ID（新）
        /// </summary>
        public string ProjectIds { get; set; }

        /// <summary>
        /// 设置的员工离职日期，为空时表示未设置离职日期，格式为"2018-07-01“
        /// </summary>
        public string SetDismissTime { get; set; }

        /// <summary>
        /// 员工实际离职日期,为空的时候表示未离职,格式为"2018-07-01 13:24:54"
        /// </summary>
        public string DismissTime { get; set; }

    }
}
