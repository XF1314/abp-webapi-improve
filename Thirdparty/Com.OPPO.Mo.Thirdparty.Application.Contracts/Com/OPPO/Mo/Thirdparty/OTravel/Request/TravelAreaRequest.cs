using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OTravel.Request
{
    public class TravelAreaRequest: TravelBaseRequest
    {

        [JsonProperty("method")]
        public string Method { get; set; } = "zas.findarea";

    }
}
