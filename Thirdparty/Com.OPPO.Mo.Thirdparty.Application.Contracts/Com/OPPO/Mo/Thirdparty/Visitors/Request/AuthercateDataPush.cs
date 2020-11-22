using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Visitors.Request
{
    public class AuthercateDataPush:BaseEsbRequest
    {
        [JsonProperty("send_data")]
        public string Data { get; set; }
    }
}
