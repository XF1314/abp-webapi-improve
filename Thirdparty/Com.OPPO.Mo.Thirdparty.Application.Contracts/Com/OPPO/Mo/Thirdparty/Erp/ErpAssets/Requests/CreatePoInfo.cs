using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests
{

    public class CreatePoInfo: CreatePoInfoBase
    {
        /// <summary>
        /// 税码
        /// </summary>
        [JsonProperty("tax_code")] 
        public string TaxCode { get; set; }
        /// <summary>
        /// 来源订单
        /// </summary>
        [JsonProperty("source_order")] 
        public string SourceOrder { get; set; }
        /// <summary>
        /// 来源系统
        /// </summary>
        [JsonProperty("source_system")] 
        public string SourceSystem { get; set; }
    }

}
