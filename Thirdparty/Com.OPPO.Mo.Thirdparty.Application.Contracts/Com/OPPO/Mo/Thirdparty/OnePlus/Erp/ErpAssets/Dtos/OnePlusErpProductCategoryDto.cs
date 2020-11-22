using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos
{
    public class OnePlusErpProductCategoryDto
    {
        /// <summary>
        /// 产品大类Code
        /// </summary>
        [JsonProperty("PROFI_SEG2")]
        public string Profi_Seg2 { get; set; }
        /// <summary>
        /// 产品大类中文名称
        /// </summary>
        [JsonProperty("PROFI_SEG2_CN")]
        public string Profi_Seg2_Cn { get; set; }
        /// <summary>
        /// 产品大类英文名称
        /// </summary>
        [JsonProperty("PROFI_SEG2_EN")]
        public string Profi_Seg2_En { get; set; }
    }
}
