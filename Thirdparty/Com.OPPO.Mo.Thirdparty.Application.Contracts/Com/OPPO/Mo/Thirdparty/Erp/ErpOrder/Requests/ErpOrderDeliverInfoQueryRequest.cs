using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{

    public class ErpOrderDeliverInfoQueryRequest : BaseEsbRespTypeRequest
    {
        [JsonProperty("p_doc_id")]
        public string DocId { get; set; }
    }
}
