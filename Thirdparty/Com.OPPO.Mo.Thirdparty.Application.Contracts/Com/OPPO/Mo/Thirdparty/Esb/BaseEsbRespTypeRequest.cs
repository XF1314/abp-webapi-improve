using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty
{

    public class BaseEsbRespTypeRequest : BaseEsbRequest
    {
        [JsonProperty("resp_type")]
        public string ResponseType { get; set; }
    }
}
