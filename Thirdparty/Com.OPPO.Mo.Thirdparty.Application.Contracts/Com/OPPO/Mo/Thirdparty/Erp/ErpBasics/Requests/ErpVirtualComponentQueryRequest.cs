using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Requests
{
    public class ErpVirtualComponentQueryRequest:BaseEsbRequest
    {
        [JsonProperty("p_item")]
        public string ItemCode { get; set; }
    }
}
