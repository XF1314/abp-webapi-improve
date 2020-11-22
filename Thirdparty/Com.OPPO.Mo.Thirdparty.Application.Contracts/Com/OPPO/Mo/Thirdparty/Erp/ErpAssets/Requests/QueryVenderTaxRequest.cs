using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests
{

    public class QueryVenderTaxRequest : BaseEsbLanguageRequest
    {
        [JsonProperty("vendor_code")]
        public string VendorCode { get; set; }
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }

    }
}
