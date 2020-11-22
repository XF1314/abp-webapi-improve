using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Mes.Requests
{
    public class MoDocToMesRequest: BaseEsbRequest
    {
        [JsonProperty("mo_documents")]
        public string Datas { get; set; }
    }
}
