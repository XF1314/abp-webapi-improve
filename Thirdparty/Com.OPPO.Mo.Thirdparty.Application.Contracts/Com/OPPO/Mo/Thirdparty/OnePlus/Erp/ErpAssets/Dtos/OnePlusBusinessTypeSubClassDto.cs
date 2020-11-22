using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos
{
    /// <summary>
    /// 业务类型子类
    /// </summary>
    public class OnePlusBusinessTypeSubClassDto
    {
        /// <summary>
        /// 业务类型子类ID
        /// </summary>
        [JsonProperty("SUBAC_SEG2")]
        public string Subac_Seg1 { get; set; }
        /// <summary>
        /// 业务类型子类中文名称
        /// </summary>
        [JsonProperty("SUBAC_SEG2_CN")]
        public string Subac_Seg1_Cn { get; set; }
        /// <summary>
        /// 业务类型子类英文名称
        /// </summary>
        [JsonProperty("SUBAC_SEG2_EN")]
        public string Subac_Seg2_En { get; set; }
    }
}
