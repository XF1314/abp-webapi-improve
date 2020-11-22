using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Mes.Requests
{
    public class MesAssetInfoQueryRequest:BaseEsbRequest
    {
        [JsonProperty("mat_id")]
        public string AssetsNumber { get; set; }
    }
}
