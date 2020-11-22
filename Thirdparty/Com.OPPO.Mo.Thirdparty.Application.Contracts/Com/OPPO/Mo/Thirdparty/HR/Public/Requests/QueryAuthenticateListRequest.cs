using Com.OPPO.Mo.Thirdparty.Erp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Requests
{

    public class QueryAuthenticateListRequest : BaseEsbRespTypeRequest
    {
        [JsonProperty("emplid")]
        public string EmployId { get; set; }
    }
}
