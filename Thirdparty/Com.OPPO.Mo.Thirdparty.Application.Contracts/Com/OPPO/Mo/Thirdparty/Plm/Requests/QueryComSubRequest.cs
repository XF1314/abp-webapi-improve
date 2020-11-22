using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Requests
{

    public class QueryComSubRequest : BaseEsbRequest
    {

        [JsonProperty("docNumber")]
        public string DocNumber { get; set; }


    }

}
