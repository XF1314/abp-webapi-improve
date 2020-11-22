using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Requests
{

    public class QueryItemInfoRequest : BaseEsbRequest
    {
     
        [JsonProperty("originOrgCode")]
        public string OrgCode { get; set; }

        [JsonProperty("itemCode")]
        public string ItemCode { get; set; }
    }
}
