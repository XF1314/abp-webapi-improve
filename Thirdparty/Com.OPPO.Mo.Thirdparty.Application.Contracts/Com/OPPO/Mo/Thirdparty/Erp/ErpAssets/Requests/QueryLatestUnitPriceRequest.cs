using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests
{
    public class QueryLatestUnitPriceRequest : BaseEsbLanguageRequest
    {
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        [JsonProperty("vendor_code")]
        public string VendorCode { get; set; }

    }
}
