using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Mes.Responses
{
    public class MesProductModelResponse
    {
        [JsonProperty("PRODUCTION_MODEL")]
        public string ProductModel { get; set; }
    }


}
