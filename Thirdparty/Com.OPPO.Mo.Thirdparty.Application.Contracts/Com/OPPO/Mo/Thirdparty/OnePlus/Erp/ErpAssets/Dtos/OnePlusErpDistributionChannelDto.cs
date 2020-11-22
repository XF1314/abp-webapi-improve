using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos
{
    public class OnePlusErpDistributionChannelDto
    {
        /// <summary>
        /// 销售渠道Code
        /// </summary>
        [JsonProperty("PROFI_SEG3")]
        public string Profi_Seg3 { get; set; }
        /// <summary>
        /// 销售渠道中文名称
        /// </summary>
        [JsonProperty("PROFI_SEG3_CN")]
        public string Profi_Seg3_Cn { get; set; }
        /// <summary>
        /// 销售渠道英文名称
        /// </summary>
        [JsonProperty("PROFI_SEG3_EN")]
        public string Profi_Seg3_En { get; set; }
    }
}
