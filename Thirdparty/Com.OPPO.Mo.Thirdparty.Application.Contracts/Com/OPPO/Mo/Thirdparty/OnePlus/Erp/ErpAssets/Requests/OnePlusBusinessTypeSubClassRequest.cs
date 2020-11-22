using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Requests
{
    public class OnePlusBusinessTypeSubClassRequest : BaseEsbRequest
    {
        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }
        /// <summary>
        /// 业务类型大类Code
        /// </summary>
        [JsonProperty("subac_seg1")]
        public string Subac_Seg1 { get; set; }
    }
}
