using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos
{
    /// <summary>
    /// 业务类型大类
    /// </summary>
    public class OnePlusErpBusinessTypeCategoryDto
    {
        /// <summary>
        /// 业务类型大类ID
        /// </summary>
        [JsonProperty("SUBAC_SEG1")]
        public string Subac_Seg1 { get; set; }
        /// <summary>
        /// 业务类型大类中文名称
        /// </summary>
        [JsonProperty("SUBAC_SEG1_CN")]
        public string Subac_Seg1_Cn { get; set; }
        /// <summary>
        /// 业务类型大类英文名称
        /// </summary>
        [JsonProperty("SUBAC_SEG1_EN")]
        public string Subac_Seg2_En { get; set; }

    }
}
