using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    public class MaterialInfos
    {

        public int TotalCount { get; set; }


        public List<MaterialInfo> MaterialCodes { get; set; }
        
        //public string MaterialCodes { get; set; }
    }

    public class MaterialInfoResponse
    {
        [JsonProperty("response")]
        public MaterialInfosDto Response { get; set; }

    }
}
