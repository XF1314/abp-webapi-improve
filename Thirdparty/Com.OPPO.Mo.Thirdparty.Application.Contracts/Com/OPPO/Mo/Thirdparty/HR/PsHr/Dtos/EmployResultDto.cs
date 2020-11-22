using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Dtos
{

    public class ContentItemDto
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [JsonProperty("hhrEmplid")] public string EmployeeId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [JsonProperty("hhrEmplName")] public string EmplName { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        [JsonProperty("hhrHireDt")] public string HireDt { get; set; }
        /// <summary>
        /// 社会工龄
        /// </summary>
        [JsonProperty("hhrSeniority")] public int Seniority { get; set; }
        /// <summary>
        /// 在职状态
        /// </summary>
        [JsonProperty("hhrHrStatus")] public string HrStatus { get; set; }
        /// <summary>
        /// CRSE标识
        /// </summary>
        [JsonProperty("hhrCrseFlag")] public string CrseFlag { get; set; }
        /// <summary>
        /// 员工类别
        /// </summary>
        [JsonProperty("hhrEmplClass")] public string EmplClass { get; set; }
        /// <summary>
        /// 员工类别描述
        /// </summary>
        [JsonProperty("hhrEmplClassDescr")] public string EmplClassDescr { get; set; }
        /// <summary>
        /// 薪资组
        /// </summary>
        [JsonProperty("hhrPayGroup")] public string PayGroup { get; set; }
        /// <summary>
        /// 工作城市
        /// </summary>
        [JsonProperty("hhrLocation")] public string Location { get; set; }
        /// <summary>
        /// 工作城市描述
        /// </summary>
        [JsonProperty("hhrLocationDescr")] public string LocationDescr { get; set; }
        /// <summary>
        /// 纳税单位
        /// </summary>
        [JsonProperty("hhrPayUnit")] public string PayUnit { get; set; }
        /// <summary>
        /// 纳税单位描述
        /// </summary>
        [JsonProperty("hhrPayUnitDescr")] public string PayUnitDescr { get; set; }
        /// <summary>
        /// 纳税单位生效日期
        /// </summary>
        [JsonProperty("hhrPayEffdt")] public string PayEffdt { get; set; }
        /// <summary>
        /// 纳税单位城市 
        /// </summary>
        [JsonProperty("hhrPayLocn")] public string PayLocn { get; set; }
        /// <summary>
        /// 纳税单位城市描述
        /// </summary>
        [JsonProperty("hhrPayLocnDescr")] public string PayLocnDescr { get; set; }
        /// <summary>
        /// 纳税部门
        /// </summary>
        [JsonProperty("hhrTaxDept")] public string TaxDept { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [JsonProperty("hhrLastUpDateTime")] public string LastUpDateTime { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [JsonProperty("hhrBirthDate")] public string BirthDate { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        [JsonProperty("hhrEduLevel")] public string EduLevel { get; set; }
        /// <summary>
        /// 转正日期
        /// </summary>
        [JsonProperty("hhrProbationDate")] public string ProbationDate { get; set; }
        /// <summary>
        /// 学历获取日期
        /// </summary>
        [JsonProperty("hhrEduEffdt")] public string EduEffdt { get; set; }
        /// <summary>
        /// 离职日期
        /// </summary>
        [JsonProperty("hhrLastWorkDate")] public string LastWorkDate { get; set; }
    }



    public class EmployResultDto
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public List<ContentItemDto> entrys { get; set; }
        /// <summary>
        /// 行数
        /// </summary>
        public int totalRows { get; set; }

    }


}
