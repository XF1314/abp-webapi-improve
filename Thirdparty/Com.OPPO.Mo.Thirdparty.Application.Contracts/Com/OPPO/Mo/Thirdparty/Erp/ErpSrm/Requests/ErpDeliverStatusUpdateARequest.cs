using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Requests
{

    public class ErpDeliverStatusUpdateARequest : BaseEsbRequest
    {
        [JsonProperty("doc_id")]
        public string DocId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }

    }
}
