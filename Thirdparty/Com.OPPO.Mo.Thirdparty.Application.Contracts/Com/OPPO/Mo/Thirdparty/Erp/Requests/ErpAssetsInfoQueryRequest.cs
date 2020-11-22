using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    public class ErpAssetsInfoQueryRequest:BaseEsbRequest
    {
        [JsonProperty("assets_number")]
        public string AssetsNumber { get; set; }
    }
}
