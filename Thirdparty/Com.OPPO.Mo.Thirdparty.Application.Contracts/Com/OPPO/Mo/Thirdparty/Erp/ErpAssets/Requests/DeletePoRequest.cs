using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests
{
 
    public class DeletePoRequest : BaseEsbRespTypeRequest
    {
        [JsonProperty("seq_id")]
        public string SeqId { get; set; }

    }
}
