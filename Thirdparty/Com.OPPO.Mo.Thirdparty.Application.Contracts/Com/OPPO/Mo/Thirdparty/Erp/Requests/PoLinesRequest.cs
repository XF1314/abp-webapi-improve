using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    public class PoLinesRequest : BaseEsbRequest
    {
        [JsonProperty("po_lines")]
        public string PoLines { get; set; }

    }
}
