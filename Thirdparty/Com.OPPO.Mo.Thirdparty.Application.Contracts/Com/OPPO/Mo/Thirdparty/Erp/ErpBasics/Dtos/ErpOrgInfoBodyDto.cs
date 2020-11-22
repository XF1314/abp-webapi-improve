using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos
{
    public class ErpOrgInfoBodyDto 
    {
        /// <summary>
        /// 组织信息条数
        /// </summary>
        public int total_results { get; set; }
        /// <summary>
        /// 组织信息
        /// </summary>
        public List<OrgInfoDto> orgs { get; set; }

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

    }
}
