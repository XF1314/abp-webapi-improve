using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Requests
{
    public class OnePlusGetDistributionChannelRequest : BaseEsbRequest
    {
        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }
        /// <summary>
        /// 战区Code
        /// </summary>
        [JsonProperty("profi_seg1")]
        public string Profi_Seg1 { get; set; }
        /// <summary>
        /// 产品大类Code
        /// </summary>
        [JsonProperty("profi_seg2")]
        public string Profi_Seg2 { get; set; }
    }
}
