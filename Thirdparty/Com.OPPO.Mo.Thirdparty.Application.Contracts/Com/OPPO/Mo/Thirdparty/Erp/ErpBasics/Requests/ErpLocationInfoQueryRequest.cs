using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Requests
{


    public class ErpLocationInfoQueryRequest : BaseEsbLanguageRequest
    {
        [JsonProperty("organization_code")]
        public string OrganizationCode { get; set; }


    }

}
