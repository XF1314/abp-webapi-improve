using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    public class LinesRequest: BaseEsbRequest
    {
        [JsonProperty("lines")]
        public string Data { get; set; }
    }
}
