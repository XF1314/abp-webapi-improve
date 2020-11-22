using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Responses
{
    public class EmployResult
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public List<ContentItem> Datas { get; set; }
        /// <summary>
        /// 行数
        /// </summary>
        public int TotalRows { get; set; }
    }

    public class ContentItem
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string EmplName { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        public string HireDt { get; set; }
        /// <summary>
        /// 社会工龄
        /// </summary>
        public int Seniority { get; set; }
        /// <summary>
        /// 在职状态
        /// </summary>
        public string HrStatus { get; set; }
        /// <summary>
        /// CRSE标识
        /// </summary>
        public string CrseFlag { get; set; }
        /// <summary>
        /// 员工类别
        /// </summary>
        public string EmplClass { get; set; }
        /// <summary>
        /// 员工类别描述
        /// </summary>
        public string EmplClassDescr { get; set; }
        /// <summary>
        /// 薪资组
        /// </summary>
        public string PayGroup { get; set; }
        /// <summary>
        /// 工作城市
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 工作城市描述
        /// </summary>
        public string LocationDescr { get; set; }
        /// <summary>
        /// 纳税单位
        /// </summary>
        public string PayUnit { get; set; }
        /// <summary>
        /// 纳税单位描述
        /// </summary>
        public string PayUnitDescr { get; set; }
        /// <summary>
        /// 纳税单位生效日期
        /// </summary>
        public string PayEffdt { get; set; }
        /// <summary>
        /// 纳税单位城市 
        /// </summary>
        public string PayLocn { get; set; }
        /// <summary>
        /// 纳税单位城市描述
        /// </summary>
        public string PayLocnDescr { get; set; }
        /// <summary>
        /// 纳税部门
        /// </summary>
        public string TaxDept { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public string LastUpDateTime { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string EduLevel { get; set; }
        /// <summary>
        /// 转正日期
        /// </summary>
        public string ProbationDate { get; set; }
        /// <summary>
        /// 学历获取日期
        /// </summary>
        public string EduEffdt { get; set; }
        /// <summary>
        /// 离职日期
        /// </summary>
        public string LastWorkDate { get; set; }
    }

}
