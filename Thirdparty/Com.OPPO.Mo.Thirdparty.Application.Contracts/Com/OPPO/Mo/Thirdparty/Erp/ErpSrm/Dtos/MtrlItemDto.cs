using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Dtos
{
    public class MtrlItemDto
    {
        /// <summary>
        /// 组织信息
        /// </summary>
        [JsonProperty("organization_code")] 
        public string OrgCode { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        [JsonProperty("segment1")] 
        public string ItemCode { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("onhandqty")] 
        public double Quantity { get; set; }
    }
}
