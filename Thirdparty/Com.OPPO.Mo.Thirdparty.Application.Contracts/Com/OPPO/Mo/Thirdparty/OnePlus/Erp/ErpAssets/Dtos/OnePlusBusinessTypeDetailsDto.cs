using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos
{
    public class OnePlusBusinessTypeDetailsDto
    {
        /// <summary>
        /// 业务类型明细ID
        /// </summary>
        [JsonProperty("SUBAC_SEG3")]
        public string Subac_Seg3 { get; set; }
        /// <summary>
        /// 业务类型明细中文名称
        /// </summary>
        [JsonProperty("SUBAC_SEG3_CN")]
        public string Subac_Seg3_Cn { get; set; }
        /// <summary>
        /// 业务类型明细英文名称
        /// </summary>
        [JsonProperty("SUBAC_SEG3_EN")]
        public string Subac_Seg3_En { get; set; }
    }
}
