using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Requests
{

    public class CheckItemIsGroupRequest : BaseEsbRespTypeRequest
    {
        [JsonProperty("v_fac_code")]
        public string FactoryCode { get; set; }
        [JsonProperty("v_primary_item")]
        public string PrimaryItemCode { get; set; }
        [JsonProperty("v_subs_tem")]
        public string SubsItemCode { get; set; }
    }
}
