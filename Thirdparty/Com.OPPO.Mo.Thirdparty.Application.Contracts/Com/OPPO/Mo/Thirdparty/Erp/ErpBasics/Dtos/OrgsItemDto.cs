using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos
{
    public class OrgInfoDto
    {
        /// <summary>
        /// 组织id
        /// </summary>
        [JsonProperty("org_id")]
        public int OrgId { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }
        /// <summary>
        /// 组织类型
        /// </summary>
        [JsonProperty("org_type")] 
        public string OrgType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_date")] 
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 上次更新日期
        /// </summary>
        [JsonProperty("last_update_date")]
        public DateTime LastUpdateDate { get; set; }
    }
}
