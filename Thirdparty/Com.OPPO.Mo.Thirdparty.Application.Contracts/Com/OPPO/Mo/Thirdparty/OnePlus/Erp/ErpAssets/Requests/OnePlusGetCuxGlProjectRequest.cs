using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Requests
{
    public class OnePlusGetMarketingBudgetProjectRequest : BaseEsbRequest
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// 研发预算项目
        /// </summary>
        [JsonProperty("proje_seg2")]
        public string Proje_Seg2 { get; set; }
    }
}
