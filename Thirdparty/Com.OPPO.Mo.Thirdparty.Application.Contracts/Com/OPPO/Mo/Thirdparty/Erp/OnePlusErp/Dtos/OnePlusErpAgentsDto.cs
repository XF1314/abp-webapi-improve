using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 采购员信息
    /// </summary>
    public class OnePlusErpAgentsDto
    {
        /// <summary>
        /// 采购员id
        /// </summary>
        [JsonProperty("AGENT_ID")]
        public string AgentId { get; set; }

        /// <summary>
        /// 采购员名称
        /// </summary>
        [JsonProperty("AGENT_NAME")]
        public string AgentName { get; set; }

        /// <summary>
        /// 采购员工号
        /// </summary>
        [JsonProperty("EMPLOYEE_NUMBER")]
        public string EmployeeNumber { get; set; }
    }
}
