using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Requests
{
    public class ErpDeliverStatusUpdateBRequest: ErpDeliverStatusUpdateARequest
    {
        [JsonProperty("iqc_status")]
        public string IqcStatus { get; set; }
    }
}
