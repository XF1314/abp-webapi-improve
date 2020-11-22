using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests
{

    public class QueryPurchaseOrderRequest : BaseEsbLanguageRequest
    {
        [JsonProperty("doc_id")]
        public string DocId { get; set; }

    }
}
