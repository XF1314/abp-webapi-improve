using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Requests
{

    public class QueryAssetRetirementRequest : BaseEsbLanguageRequest
    {
        [JsonProperty("info_number")]
        public string InfoNumber { get; set; }

    }
}
