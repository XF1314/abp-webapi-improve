using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Requests
{
    public class ErpOrgListQueryRequest: BaseEsbRespTypeRequest
    {
        [JsonProperty("date_from")]
        public string StartDate { get; set; }
        [JsonProperty("date_to")]
        public string EndDate { get; set; }
    }
}
