using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos
{
    public class OnePlusErpBelongAreaDto
    {
        /// <summary>
        /// 所属地区Code
        /// </summary>
        [JsonProperty("PROFI_SEG4")]
        public string Profi_Seg4 { get; set; }
        /// <summary>
        /// 所属地区中文名称
        /// </summary>
        [JsonProperty("PROFI_SEG4_CN")]
        public string Profi_Seg4_Cn { get; set; }
        /// <summary>
        /// 所属地区英文名称
        /// </summary>
        [JsonProperty("PROFI_SEG4_EN")]
        public string Profi_Seg4_En { get; set; }
    }
}
