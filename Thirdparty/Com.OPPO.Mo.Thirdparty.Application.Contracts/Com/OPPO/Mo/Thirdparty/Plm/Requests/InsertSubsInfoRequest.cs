using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Requests
{

    public class InsertSubsInfoRequest : BaseEsbRequest
    {
        [JsonProperty("comsub_info")]
        public string Data { get; set; }

    }
}
