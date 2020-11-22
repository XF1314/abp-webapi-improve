using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos
{
    /// <summary>
    /// Erp 战区
    /// </summary>
    public class OnePlusErpWarZoneDto
    {
        /// <summary>
        /// 战区Code
        /// </summary>
        [JsonProperty("PROFI_SEG1")]
        public string Profi_Seg1 { get; set; }
        /// <summary>
        /// 战区中文名称
        /// </summary>
        [JsonProperty("PROFI_SEG1_CN")]
        public string Profi_Seg1_Cn { get; set; }
        /// <summary>
        /// 战区英文名称
        /// </summary>
        [JsonProperty("PROFI_SEG1_EN")]
        public string Profi_Seg2_En { get; set; }
    }
}
