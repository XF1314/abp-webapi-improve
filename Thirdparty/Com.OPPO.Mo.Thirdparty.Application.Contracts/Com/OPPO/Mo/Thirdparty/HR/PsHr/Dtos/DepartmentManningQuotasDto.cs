
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{

    public class DepartmentManningQuotasDto
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

        /// <summary>
        /// 组织部门编号
        /// </summary>
        [JsonProperty("m_dept_id")]
        public string OrgDepartmentId { get; set; }

        /// <summary>
        /// 编制总数
        /// </summary>
        [JsonProperty("m_dept_ch_count")] 
        public string TotalCompilation { get; set; }

        /// <summary>
        /// 占编制总数
        /// </summary>
        [JsonProperty("m_dept_ch_use")] 
        public string InTotal { get; set; }

        /// <summary>
        /// 是否可以发起（Y/N）
        /// </summary>
        [JsonProperty("flag")] 
        public string IsLaunch { get; set; }

        /// <summary>
        /// 组织编制数据
        /// </summary>
        [JsonProperty("data")] 
        public List<OrganizationCompilationDto> Datas { get; set; }
    }

    public class OrganizationCompilationDto
    {
        /// <summary>
        /// 组织编号
        /// </summary>
        [JsonProperty("deptid")] 
        public string DepartmentId { get; set; }

        /// <summary>
        /// 组织编制总数
        /// </summary>
        [JsonProperty("deptdc")] 
        public string DepartmentCount { get; set; }

        /// <summary>
        /// 组织占编制总数
        /// </summary>
        [JsonProperty("deptdu")] 
        public string DepartmenInTotal { get; set; }

        /// <summary>
        /// 组织审批编制总数(外聘)
        /// </summary>
        [JsonProperty("deptdw")] 
        public string DepartmenApprovalTotalOut { get; set; }

        /// <summary>
        /// 组织审批编制总数(内聘)
        /// </summary>
        [JsonProperty("deptdn")] 
        public string DepartmenApprovalTotalIn { get; set; }
    }
}
